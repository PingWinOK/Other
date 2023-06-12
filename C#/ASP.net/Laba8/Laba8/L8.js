function Foo() {
    var x;
    var a = document.getElementById("1").value;
    var b = document.getElementById("2").value;
    var Bol;
    var Men;
    var Rez = 0;
    if(a > b)
    {
        Bol = a +1;
        Men = b;
    }
    else
        {
        Bol = b + 1;
            Men = a;
    }
    for (var i = Men; i < (Bol); i++)
    {
        Rez += Math.pow(i, 2);

    }
    document.getElementById("Rez").innerHTML = Rez;


}