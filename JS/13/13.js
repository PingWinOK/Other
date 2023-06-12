function Foo1()
{
var Otv = 0
var n = document.getElementById("1").value 
F(n);
function F(n)
{

    if(n >= 1)
    {
        F(n-1) + F(n-2)
    }
    else if((n == 0) || (n == 1))
    {
      Otv += 1
    }
}
document.getElementById("rez1").innerHTML = Otv
}
function Foo2()
{
    var elem = document.getElementById('canvas');
    var ctx = elem.getContext('2d');

    var depth = 10; //глубина рекурсии ( ее можно менять)
    ctx.lineWidth = 3; //толщина линий
    ctx.strokeStyle = 'blue'; // цвет
    R = 50
    t = 10
    Visota = 300
    Hirina = 300
    var K = 1.5



    function drawKrug(Visota, Hirina, R) 
    { 
    ctx.beginPath()
    ctx.arc(Visota, Hirina, R, 0, Math.PI * 2, true)
    //ctx.moveTo(Visota, Hirina)
    ctx.closePath(); //закончить
    ctx.stroke();

    }
    function drawKrugs(Visota, Hirina,R , depth) 
    { 
        if (depth) 
        {

            drawKrug(Visota, Hirina,R/K);
            if (R > 2) {
                var R2 = R
                R = R / K

               
                drawKrugs(Visota, Hirina - R2 - R / K, R/K, depth - 1);
                drawKrugs(Visota + R2 + R / K, Hirina, R/K, depth - 1);
                drawKrugs(Visota, Hirina + R2 + R / K, R/K, depth - 1);
                drawKrugs(Visota - R2 - R / K, Hirina, R/K, depth - 1);

            }




        }
    }

    drawKrugs(300, 300,R , depth); //вызвать функцию  отрисовки




}