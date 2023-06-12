#include <MQTT.h>
#include <ESP8266WiFi.h>
#include <PubSubClient.h>

const char *ssid =  "TP-LINK_4E10";  // Имя вайфай точки доступа
const char *pass =  "58655139"; // Пароль от точки доступа

const char *mqtt_server = "fe07604b.us-east-1.emqx.cloud"; // Имя сервера MQTT
const int mqtt_port = 15190; // Порт для подключения к серверу MQTT
const char *mqtt_user = "qwe"; // Логин от сервер
const char *mqtt_pass = "123"; // Пароль от сервера

bool LedState = false;
int tm=300;
float temp=0;

// Функция получения данных от сервера

void callback(const MQTT::Publish& pub)
{
  Serial.print(pub.topic());   // выводим в сериал порт название топика
  Serial.print(" => ");
  Serial.print(pub.payload_string()); // выводим в сериал порт значение полученных данных
  Serial.print("\n");
  
  String payload = pub.payload_string();
  
  if(String(pub.topic()) == "test/led") // проверяем из нужного ли нам топика пришли данные 
  {
  int stled = payload.toInt(); // преобразуем полученные данные в тип integer
  digitalWrite(2,stled);  //  включаем или выключаем светодиод в зависимоти от полученных значений данных
  }
}

WiFiClient wclient;      
PubSubClient client(wclient, mqtt_server, mqtt_port);

void setup() 
{
  Serial.begin(115200);
  delay(10);
  Serial.println();
  Serial.println();
  pinMode(2, OUTPUT);
}

void loop() 
{
  // подключаемся к wi-fi
  if (WiFi.status() != WL_CONNECTED) 
  {
    Serial.print("Connecting to ");
    Serial.print(ssid);
    Serial.println("...");
    WiFi.begin(ssid, pass);

    if (WiFi.waitForConnectResult() != WL_CONNECTED)
      return;
    Serial.println("WiFi connected");
  }

  // подключаемся к MQTT серверу
  if (WiFi.status() == WL_CONNECTED) 
  {
    if (!client.connected()) 
    {
      Serial.println("Connecting to MQTT server");
      if (client.connect(MQTT::Connect("arduinoClient2")
                         .set_auth(mqtt_user, mqtt_pass))) 
      {
        Serial.println("Connected to MQTT server");
        client.set_callback(callback);
        client.subscribe("test/led"); // подписывааемся по топик с данными для светодиода
      } 
      else 
      {
        Serial.println("Could not connect to MQTT server");   
      }
    }

    if (client.connected())
    {
      client.loop();
    }
  
  }
} // конец основного цикла
