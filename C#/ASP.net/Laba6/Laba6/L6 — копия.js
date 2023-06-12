function
    foo() {
    var x = parseInt(document.getElementById('X').value);
    var y = parseInt(document.getElementById('Y').value);
    if (isNaN(x) == true) x = 0;
    if (isNaN(y) == true) y = 0;
    var f;
    if (document.getElementById('f1').checked == true) { f = parseInt(document.getElementById('f1').value); }
    if (document.getElementById('f2').checked == true) { f = parseInt(document.getElementById('f2').value); }
    if (document.getElementById('f3').checked == true) { f = parseInt(document.getElementById('f3').value); }

    var rez;
    var x1;
    var y1;
var z;
    switch (f)
    {
        case 1:
            x1 = Math.cos(x);
            y1 = Math.cos(y);
	z= Math.cos(Math.tan(y));
            break;
        case 2:
            x1 = Math.sqrt(x);
            y1 = Math.sqrt(y);
	z= Math.sqrt(Math.tan(y));
            break;
        case 3:
            x1 = Math.exp(x);
            y1 = Math.exp(y);
	z= Math.exp(Math.tan(y));
            break;
    }

    if ((x / y) > 0)
    {
        rez = Math.log(x) + y1;
        }
    if ((x / y) < 0)
    {
        rez = Math.abs(x) - Math.tan(y1)
        }
    else
    {
        x1 * Math.pow(y, 3);
    }
    if (document.getElementById('sok').checked)
    {
        rez = Math.round(rez);
    }

    document.getElementById("rez").innerHTML = "Результат: " + rez;
}

