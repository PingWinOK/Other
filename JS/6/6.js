function randomInteger(min, max) {
    let rand = min - 0.5 + Math.random() * (max - min + 1);
    return Math.round(rand);
}
var Mass = [];
function Massiv() {
    Mass = [];
    var A = document.getElementById("1").value;
    for (i = 0; i < A; i++) {
        Mass.push(randomInteger(0, 100));
    }
}
function Обмен(Mass)
{
    var R = Mass[Mass.length-1]
    Mass[Mass.length-1] = Mass[0]
    Mass[0] = R
    return Mass;
}
function Сортировка_Шелла(Mass)
{
    var n = Mass.length, i = Math.floor(n/2);
    while (i > 0)
     { for (var j = 0; j < n; j++)
        { 
        var k = j;
        t = Mass[j];
          while (k >= i && Mass[k-i] > t)
           {
                Mass[k] = Mass[k-i]; 
                k -= i;
            }
           Mass[k] = t;
        }
      i = (i==2) ? 1 : Math.floor(i*5/11);
     }
    return Mass;
}
function Сортировка_пузырьком(Mass) {
    var I = 0
    var J = 0
    for (var i = 0, I = Mass.length - 1; i < I; i++) 
    {
        for (var j = 0, J = I - i; j < J; j++) 
        {
            if (Mass[j] > Mass[j + 1]) 
            {
                var swap = Mass[j];
                Mass[j] = Mass[j + 1];
                Mass[j + 1] = swap;
            }
        }
    }
    return Mass;
}

function Сортировка_вставками(Mass) 
{     
    var n = Mass.length;
    for (var i = 0; i < n; i++)
    { 
        var v = Mass[i];
        var j = i-1;
    while (j >= 0 && Mass[j] > v)
    { 
        Mass[j+1] = Mass[j]; 
        j--; 
    }
        Mass[j+1] = v;
    }                    
    return Mass;
}

function Foo1()
{
    A = document.getElementById("1").value;
    Massiv()
    document.getElementById("rez1").innerHTML = Mass.toString();
    Сортировка_пузырьком(Mass)
    Обмен(Mass)
    document.getElementById("rez2").innerHTML = Mass.toString();
}
function Foo2()
{
    A = document.getElementById("1").value;
    Massiv()
    document.getElementById("rez3").innerHTML = Mass.toString();
    Сортировка_Шелла(Mass)
    Обмен(Mass)
    document.getElementById("rez4").innerHTML = Mass.toString();
}
function Foo3()
{
    A = document.getElementById("1").value;
    Massiv()
    document.getElementById("rez5").innerHTML = Mass.toString();
    Сортировка_вставками(Mass)
    Обмен(Mass)
    document.getElementById("rez6").innerHTML = Mass.toString();
}