function Human(name, fam, login,pass) {
    this.name = name;
    this.fam = fam;
    this.login = login;
    this.pass = pass;
}




function Vhod() {
    var login = document.getElementById("1").value;
    var pass = document.getElementById("2").value;
    Pers = [];
    Pers[0] = (Human1 = new Human("Данил","Кулаков","123","321"));
    Pers[1] = (Human2 = new Human("Михаил","Минаков","111","111"));
    Pers[2] = (Human3 = new Human("Дмитрий","Филин","222","222"));
    for(var i in Pers)
    {
        if(Pers[i].login == login && Pers[i].pass == pass)
        {
            document.getElementById("rez").innerHTML = "Добро пожаловать " + Pers[i].name +" "+ Pers[i].fam +"";
            break;
        }
        else
        {
            document.getElementById("rez").innerHTML = "Неверные логин или пароль";
        }
    }
}
function Foo() {
    A = parseInt(document.getElementById("3").value);
    B = parseInt(document.getElementById("4").value);

    function Fun(name, id, A, B, Rez) {
        this.name = name;
        this.id = id;
        this.A = A;
        this.B = B;
        this.Rez = Rez;
    }

    Pere = [];
    Pere[0] = (Operazia = new Fun("Сложение", 1, A, B,function () {
        var Rez; if (this.id == 1) { Rez = Number(this.A) + Number(this.B); }
        else { Rez = this.A * this.B; } return Rez
            ;
    }));
    Pere[1] = (Operazia = new Fun("Умножение", 2, A, B, function () {
        var Rez; if (this.id == 1) { Rez = this.A + this.B; } else { Rez = this.A * this.B; } return Rez
    }));
    

    document.getElementById("rez1").innerHTML = "Сложение: " +Pere[0].Rez();
    document.getElementById("rez2").innerHTML = "Умножение: " + Pere[1].Rez();

}