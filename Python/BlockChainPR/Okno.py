import sys
from PyQt5 import QtWidgets
from PyQt5.QtGui import QColor

import Transaction_management
import Client as Client
import data as data

IBCoins = []
Clients = []
Transactions = []
Block = []


def mine(listWidget_5,listWidget_6,message, difficulty=1):
    listWidget_5.clear()
    assert difficulty >= 1
    prefix = '9' * difficulty
    for data.x in range(100000000):
        HashMine = Client.sha256(str(hash(message)) + str(data.x))
        listWidget_5.addItem(str(HashMine))
        if HashMine.startswith(prefix):
            listWidget_5.item(listWidget_5.count()-1).setBackground(QColor('#7fc97f'))
            return HashMine


class ExampleApp(QtWidgets.QMainWindow, Transaction_management.Ui_MainWindow):

    def __init__(self):
        # Это здесь нужно для доступа к переменным, методам
        # и т.д. в файле design.py
        super().__init__()
        self.setupUi(self)  # Это нужно для инициализаци дизайна
        self.pushButton.clicked.connect(self.AddPol)  # Выполнить функцию AddPol
        self.listWidget.itemSelectionChanged.connect(self.selectionChanged)
        self.pushButton_4.clicked.connect(self.AddTransaction)
        self.pushButton_6.clicked.connect(self.AddBlock)

    def AddPol(self):
        i = Client.Polz()
        count = self.listWidget.count()
        Clients.append(i)
        self.listWidget.addItem("Пользователь " + str(count))
        self.comboBox.addItem("Пользователь " + str(count))
        self.comboBox_2.addItem("Пользователь " + str(count))

    def AddTransaction(self):
        s = self.comboBox.currentText()
        r = self.comboBox_2.currentText()
        Value = self.lineEdit.text()
        #i = Client.Transaction(s[13:],r[13:],Value)
        i = Client.Transaction(Clients[int(s[13:])],Clients[int(r[13:])].identity,Value)
        signature = i.sign_transaction()
        Transactions.append(i)
        self.listWidget_3.addItem("-------------------"+ str(len(Transactions)) +"------------------")
        self.listWidget_3.addItem("Отправитель: " + "Пользователь " + str(s[13:]))
        self.listWidget_3.addItem("Получатель: " + "Пользователь " + str(r[13:]))
        self.listWidget_3.addItem("Сигнатура подписанной транзакции: " +str(signature))
        self.listWidget_3.addItem("Дата: " +str(i.time))
        self.listWidget_3.addItem("Сумма: " +str(i.value))

    def AddBlock(self):
        block = Client.Block()
        for i in range(5):
            temp_transaction = Transactions[data.last_transaction_index]
            block.verified_transactions.append(temp_transaction)
            data.last_transaction_index += 1

        block.previous_block_hash = data.last_block_hash
        block.Nonce = mine(self.listWidget_5,self.listWidget_6,block, 4)
        digest = Client.sha256(str(hash(block)))
        IBCoins.append(block)
        data.last_block_hash = digest
        self.listWidget_6.addItem("---------------------------------"+ str(len(IBCoins)) +"--------------------------------")
        self.listWidget_6.addItem("Понадобилось " + str(data.x) + " итераций для нахождения дайджеста")
        self.listWidget_6.addItem("Количество верифицированных транзакций: " +str(len(block.verified_transactions)))
        self.listWidget_6.addItem("Хеш прошлого блока: " +str(block.previous_block_hash))
        self.listWidget_6.addItem("Проверка работой: " +str(block.Nonce))
        self.listWidget_6.addItem("Хеш блока: " +str(digest))










    def selectionChanged(self):
        r = self.listWidget.currentItem().text()
        self.listWidget_2.clear()
        self.listWidget_2.addItem(Clients[int(r[13:])].identity)


def main():
    app = QtWidgets.QApplication(sys.argv)  # Новый экземпляр QApplication
    window = ExampleApp()  # Создаём объект класса ExampleApp
    window.show()  # Показываем окно
    app.exec_()  # и запускаем приложение


if __name__ == '__main__':
    main()
