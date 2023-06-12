function Laba4()
{
    var x = parseFloat(document.getElementById('1').value);
    var y = 0.75 * (10 ** (-4));
    var z = 0.845 * (10 ** (-2));
    var u1 = Math.sqrt(8 + ((Math.abs(x - y)) ** 2) + 1);
    var u2 = u1 ** (1 / 3);
    var u3 = ((x ** 2) + (y ** 2) + 2);
    var u4 = u2 / u3;
    var u5 = Math.exp(Math.abs(x - y));
    var u6 = ((Math.tan(z)) ** (2) + 1) ** x;
    var rez = u4 - u5 * u6;
    document.getElementById("rez").innerHTML = "Результат: " + rez;
}