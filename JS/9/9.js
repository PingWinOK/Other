function randomInteger(min, max) {
    let rand = min - 0.5 + Math.random() * (max - min + 1);
    return Math.round(rand);
}
function getMaxOfArray(numArray) {
    return Math.max.apply(null, numArray);
  }
function getMinOfArray(numArray) {
    return Math.min.apply(null, numArray);
  }
var Mass = [] , r = "";

function Foo()
{
    Mass = []
    var N = document.getElementById("1").value;
    var M = document.getElementById("2").value;
    for (i = 0;i < N;i++)
    {
        Mass[i] = [];
        for (j = 0;j < M;j++)
        {
            Mass[i][j] = randomInteger(0,100)
            r = r + "|" + Mass[i][j]
        }
        r = r + "</br>"
    }
    document.getElementById("rez").innerHTML = r;
}
function Foo1()
{
    var N = document.getElementById("1").value;
    var M = document.getElementById("2").value;
    Sum = [], g = 0;
    for (i = 0;i < N;i++)
    {
        for (j = 0;j < M;j++)
        {
            g += Mass[i][j]
            Sum[i] = g
        }
    }
    
    document.getElementById("rez1").innerHTML = getMaxOfArray(Sum);
}
function Foo2()
{
    var N = document.getElementById("1").value;
    var M = document.getElementById("2").value;
    Sum = [], g = 0;
    for (i = 0;i < N;i++)
    {
        for (j = 0;j < M;j++)
        {
            g += Mass[j][i]
            Sum[i] = g
        }
    }
    document.getElementById("rez2").innerHTML = getMinOfArray(Sum);
}
function Foo3()
{
    Mass1 = [];
    Mass = []
    var N = document.getElementById("3").value;
    var M = document.getElementById("4").value;
    for (i = 0;i < N;i++)
    {
        Mass[i] = [];
        Mass1[i] = [];
        for (j = 0;j < M;j++)
        {
            Mass[i][j] = randomInteger(0,100)
            r = r + "|" + Mass[i][j]
        }
        r = r + "</br>"
    }
    document.getElementById("rez3").innerHTML = r;
}
function Foo4()
{
    var N = Number(document.getElementById("3").value);
    var M = Number(document.getElementById("4").value);
    var j = 0, SortDig = [];
    for (var i = 0; i < N; i++)     
    { 
         for (var j = 0; j < M; j++) 
        {
            if((i + j) == N - 1)
            {
            SortDig[i] = Mass[i][j]
            }
        }
    }
    SortDig.sort();
    h = 0,g = 0
    for (var i = 0; i < N; i++)     
    { 
         for (var j = 0; j < M; j++) 
        {
            if(((i + j) == N - 1))
            {
                for (var q = 0; q < M; q++) 
                if(Mass[j][i] == SortDig[q])
                {
                g = i
                for (var t = 0; t < N; t++)     
                { 
                Mass1[t][q] = Mass[t][g]
                }
                h++
                g++
            }
            }
        }
    }
    r = ""
    for (i = 0;i < N;i++)
    {
        for (j = 0;j < M;j++)
        {
            r = r + "|" + Mass1[i][j]
        }
        r = r + "</br>"
    }
    document.getElementById("rez4").innerHTML = r;
}
