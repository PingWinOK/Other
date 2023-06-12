function Foo() {
    var P = parseInt(document.getElementById("1").value);
    var m = parseInt(document.getElementById("2").value);
    var d = parseInt(document.getElementById("3").value);
    var S = 0, S1 = "", r = 0;
    //1
    for (var i = 1; i <= m; i++)
    {
       
        if (i == m)
        {
            r = (i / (P + 2))
            S += (i / (P + 2));
            S1 += r.toFixed(2);
        }
        else
        {
            r = (i / (P + 2))
            S += (i / (P + 2));
            S1 += r.toFixed(2) + " + ";
        }
    }
    document.getElementById("S1").innerHTML = S1;
    document.getElementById("S").innerHTML = "Результат: " + S;
}
function Fo()
    {
        var P = parseInt(document.getElementById("3").value);
        var d = parseFloat(document.getElementById("4").value);
        var S = 0, S1 = "", r = 0, i = 1;
        while (r < d)
        {
            r = (i / (P + 2));
            if (r > d)
            {
                break;
            }
            S += (i / (P + 2));
            i++;
            S1 += r.toFixed(2) + " + ";
        }

        document.getElementById("s1").innerHTML = S1+'='+S;
        document.getElementById("s").innerHTML = "Результат: " + S;
    }



