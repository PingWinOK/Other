function randomInteger(min, max) {
    let rand = min - 0.5 + Math.random() * (max - min + 1);
    return Math.round(rand);
}

function sorte(a, b) {
    if (a > b) return 1;
    if (a == b) return 0;
    if (a < b) return -1;
}
var Mass = [];

function Massiv() {
    Mass = [];
    var A = document.getElementById("1").value;
    for (i = 0; i < A; i++) {
        Mass.push(randomInteger(0, 100));
    }
}


function Foo(A) {
    Massiv();
    document.getElementById("Foo").innerHTML = Mass.toString();
}

function Foo1() {
    Mass.splice(1, 4);
    document.getElementById("Foo1").innerHTML = Mass.toString();
}

function Foo2() {
    Mass.unshift(randomInteger(0, 100));
    Mass.unshift(randomInteger(0, 100));
    document.getElementById("Foo2").innerHTML = Mass.toString();
}

function Foo3() {
    Mass.reverse();
    document.getElementById("Foo3").innerHTML = Mass.toString();
}

function Foo4() {
    Mass.sort(sorte);
    Mass.reverse();
    document.getElementById("Foo4").innerHTML = Mass.toString();
}

function Foo5() {
    Massiv();
    document.getElementById("Foo5").innerHTML = Mass.toString();
}

function Foo6() {
    Chet = []
    for (i = 0; i < Mass.length; i++) {
        if (Mass[i] % 2 == 0) {
            Chet.push(Mass[i]);
        }
    }
    document.getElementById("Foo6").innerHTML = Chet.length;
}

function Foo7() {
    Massiv();
    document.getElementById("Foo7").innerHTML = Mass.toString();
}

function Foo8() {
    var sred = 0
    for (i = 0; i < Mass.length; i++) 
    {
        sred += Mass[i];
    }
    Mass.splice(4,1,sred/Mass.length)
    document.getElementById("Foo8").innerHTML = Mass.toString();
}

function Foo9() {
    Massiv();
    document.getElementById("Foo9").innerHTML = Mass.toString();
}
function Foo10() {
    var min = Math.min.apply(null,Mass);
    var max = Math.max.apply(null,Mass)
    var mini = 0
    var maxi = 0
    for(i = 0;i < Mass.length;i++)
        {
            if(Mass[i] == min)
            {
                mini = i;
            }
            if(Mass[i] == max)
            {
                maxi = i;
            }
        }
        Mass.splice(mini,1,max)
        Mass.splice(maxi,1, min)

    

    document.getElementById("Foo10").innerHTML = Mass.toString();
}
function Foo11() {
    Massiv();
    document.getElementById("Foo11").innerHTML = Mass.toString();
}
function Foo12() {
    var j = 0;
    var sred = 0;
    for (i = 0; i < Mass.length; i++) 
    {
        sred += Mass[i];
    }
    for(i = 0;i < Mass.length;i++)
    {
        if(Mass[i] > Mass[0] && Mass[i] < (sred/Mass.length))
        {
            j += 1;
        }
    }
    document.getElementById("Foo12").innerHTML = j;
}
function Foo13() {
    Mass = [];
    var A = document.getElementById("1").value;
    for (i = 0; i < A; i++) {
        Mass.push(randomInteger(0, 2));
    }
    document.getElementById("Foo13").innerHTML = Mass.toString();
}
function Foo14() {
    for(i = 0;i < Mass.length;i++)
    {
        if(Mass[i] == 0)
        {
            Mass.splice(i,1, 10)  
        }
    }
    document.getElementById("Foo14").innerHTML = Mass.toString();
}
function Foo15() {
    Massiv();
    document.getElementById("Foo15").innerHTML = Mass.toString();
}
function Foo16() {
    var sred = 0;
    for (i = 0; i < Mass.length; i++) 
    {
        if(Mass[i]%2 !== 0)
        {
        sred += Mass[i];
        }
    }
    for (i = 0; i < Mass.length; i++) 
    {
        if(Mass[i]%3 == 0)
        {
            Mass.splice(i,1, sred) 
        }
    }
    document.getElementById("Foo16").innerHTML = Mass.toString();
}

function Foo17() {
    Massiv();
    document.getElementById("Foo17").innerHTML = Mass.toString();
}
function Foo18() {
    var g = 0;
    var min = Math.min.apply(null,Mass);
    var max = Math.max.apply(null,Mass)
    for(i = 0;i < Mass.length;i++)
    {
        if(Mass[i] == min)
        {
            mini = i;
        }
        if(Mass[i] == max)
        {
            maxi = i;
        }
    }
    if (mini > maxi) {
        i = mini;
        mini = maxi;
        maxi = i;
    }
    for (i=mini+1; i < maxi; i++)
    {
        g += 1;
    }
    document.getElementById("Foo18").innerHTML = g;
}
function Foo19() {
    Massiv();
    document.getElementById("Foo19").innerHTML = Mass.toString();
}
function Foo20() {
    var sum = 0;
    var proiz = 1;
    for(i = 0;i < Mass.length;i++)
    {
        if(i%2 == 0)
        {
            sum += Mass[i];
        }
        if(Mass[i]%2 !== 0)
        {
            proiz *= Mass[i]
        }
    }
    document.getElementById("Foo20").innerHTML = "Сумма елементов по четному индексу: " + sum +"\n"+"Произведение по нечетным елементам: "+ proiz;
}
function Foo21() {
    Massiv();
    document.getElementById("Foo21").innerHTML = Mass.toString();
}
function Foo22() {
    g = 0;
    for (i = 0; i < Mass.length; i++) 
    {
        if(Mass[i]%3 == 0)
        {
            Mass.splice(i,1, 0);
            g += 1;
        }
    }
    document.getElementById("Foo22").innerHTML = Mass.toString()+"\n"+ "Количество замен: " + g;
}
function Foo23()
{
    Mass = [];
    r = " ";
    var A = document.getElementById("2").value;
    for (i = 0; i < A; i++) {
        Mass.push(randomInteger(0, 1));
        r += Mass[i];
        
    }
    document.getElementById("Foo23").innerHTML = r;
}
function Foo24()
{
    var rez = 0;
    var j = 0;
    for (i = Mass.length; i > 0; i--) 
    {
        rez += Mass[i-1] * 2**j
        j++;
    }
        
    
    document.getElementById("Foo24").innerHTML = "В 10-й системе счисления:  " + rez;
}