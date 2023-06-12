function Foo()
{
    var n = parseInt(document.getElementById("1").value);
    var m = parseInt(document.getElementById("2").value);
    var S = 1, S1 = 0;
    for (var i = 1; i < n+1; i++)
    {
        for (var j = 1; j < m+1; j++)
        {
            S1 = (i + j);
            S *= S1;
        }
    }
    document.getElementById("S").innerHTML = S;
}

function f1()
{
    var f,r;
    if (document.getElementById('f1').checked == true) { f = parseInt(document.getElementById('f1').value); }
    if (document.getElementById('f2').checked == true) { f = parseInt(document.getElementById('f2').value); }
    if (document.getElementById('f3').checked == true) { f = parseInt(document.getElementById('f3').value); }
    switch (f) {
        case 1:
            r = "color:red";
            break;
        case 2:
            r = "color:#ffff00";
            break;
        case 3:
            r = "color:#000000";
            break;
    }
    document.getElementById("S").style = r;

}



