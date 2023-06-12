function Foo()
{
var n = 1, otv = " ";
F(n);
function F(n){
    otv = otv + n;
    if(n < 5)
    {
        F(n+2)
        F(n+5)
    }
}
document.getElementById("rez1").innerHTML = otv
}
function Foo1()
{
var n = 2, otv = " ";
F(n);
function F(n){
    otv = otv + n;
    if(n < 5)
    {
        F(n+2)
        F(n+5)
    }
}
document.getElementById("rez2").innerHTML = otv
}

function Foo2()
{
function Nadn(n)
{
if(n == 1)
{
    return 1;
}
else if(n > 1 && n < 2)
{
    return 0;
}
else
{
    return Nadn(n / 2);
}
}
n = document.getElementById("1").value
if (Nadn(n) == 1) {
    document.getElementById("rez3").innerHTML = "Yes"
} else {
    document.getElementById("rez3").innerHTML = "No"
}
}