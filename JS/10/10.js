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
function Foo()
{
var log = document.getElementById("1").value
var pass = document.getElementById("2").value
var r = RegExp(/[^a-z][а-я]/g);
try 
{
if (r.test(pass) == true)
{
throw new Error('Пароль должен быть на английском языке!');
}
if (log == "Danil" && pass == "Kulakov")
{
document.getElementById("rez").innerHTML = "Вы успешно вошли"
}
else
{
throw new Error('Неверный логин или пароль');
}
}
catch(e)
{
    document.getElementById("rez").innerHTML = e.name + ' :' + e.message;
}
}
var Mass = []
function Foo1()
{   
    r = ""
    var N = document.getElementById("3").value;
    var M = document.getElementById("4").value;
    try
    {
        if(N != M)
        {
            throw new Error('Матрица не квадратная!');
        }
        else
        {
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
    document.getElementById("rez1").innerHTML = r;
}
    }
catch(e)
{
    document.getElementById("rez1").innerHTML = e.name + ' :' + e.message;
}
}
function Foo2()
{
    var N = document.getElementById("3").value;
    var M = document.getElementById("4").value;
    Mass1 = [],Mass2 = [], max = 0, min = 0;
    for (i = 0;i < N;i++)
    {
        for (j = 0;j < M;j++)
        {
            Mass1[i] = getMaxOfArray(Mass[i])
            Mass2[i] = getMinOfArray(Mass[i])
        }
        max = getMaxOfArray(Mass1)
        min = getMinOfArray(Mass2)

    }
    MassMax = [], MassMin = [] ,MassFin = [];
    for (i = 0;i < N;i++)
    {
        MassFin[i] = []
        for (j = 0;j < M;j++)
        {
            if(Mass[i][j] == max)
            {
                for(t = 0;t < N;t++)
                {
                MassMax[t] = Mass[i][t]
                Maxi = i
                }
            }
            if(Mass[i][j] == min)
            {
                for(t = 0;t < N;t++)
                {
                MassMin[t] = Mass[i][t]
                Mini = i
                }

            }
            MassFin[i][j] = Mass[i][j]
        }
    }
        for (i = 0;i < M;i++)
        {
            for (j = 0;j < M;j++)
        {
            if(i == Mini)
            {
            for(t = 0;t < N;t++)
            {
            MassFin[i][t] = MassMax[t]
            }
            }
            if(i == Maxi)
            {
            for(t = 0;t < N;t++)
            {
            MassFin[i][t] = MassMin[t]
            }
            }
        }
    }
    r = " "
    for (i = 0;i < N;i++)
    {
        for (j = 0;j < M;j++)
        {
            r = r + "|" + MassFin[i][j]
        }
        r = r + "</br>"
    }
    document.getElementById("rez2").innerHTML = r;
}