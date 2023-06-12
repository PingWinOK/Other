function sumakvadratov(a)
{
    r = 0;
    for (i = 1;i <= a; i++)
    {
        r += Math.pow(i,2)
    }  
    return r;
}

function foo() 
{
    a = document.getElementById("1").value;
    document.getElementById("rez").innerHTML = sumakvadratov(a);
}
function foo1()
{
    var e = document.getElementsByTagName("img");
    for (var i = 0;i < e.length; i++)
    {
        e[i].style.boxShadow = "5px 5px";
    }
}
