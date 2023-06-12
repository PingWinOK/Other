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

var Mass = [];

function Massiv() {
    Mass = [];
    var A = document.getElementById("1").value;
    for (i = 0; i < A; i++) {
        Mass.push(randomInteger(0, 99));
    }
}

function Foo1() {
    Massiv();
    document.getElementById("rez1").innerHTML = Mass;
}

function Foo2() {
    for (var i = 0; i < Mass.length; i++) {
        if (Mass[i] % 10 == 4) {
            Mass[i] = Mass[i] / 2;
        }
    }
    document.getElementById("rez2").innerHTML = Mass;
}

function Foo3() {
    for (var i = 0; i < Mass.length; i++) {
        if (Mass[i] % 2 == 0) {
            Mass[i] = Mass[i] ** 2;
        }
        if (Mass[i] % 2 !== 0) {
            Mass[i] = Mass[i] * 2;
        }
    }
    document.getElementById("rez3").innerHTML = Mass;
}


function Foo4() {
    var a = document.getElementById("2").value;
    var b = document.getElementById("3").value;
    for (var i = 0; i < Mass.length; i++) {
        if (Mass[i] % 2 == 0) {
            Mass[i] = Mass[i] + Number(a);
        } else if (i % 2 == 0) {
            Mass[i] = Mass[i] - Number(b);
        }
    }
    document.getElementById("rez4").innerHTML = Mass;
}
Mass1 = [];
Mass2 = [];
Mass3 = [];

function Massiv2() {
    Mass1 = [];
    Mass2 = [];
    var A = document.getElementById("4").value;
    for (i = 0; i < A; i++) {
        Mass1.push(randomInteger(0, 99));
        Mass2.push(randomInteger(0, 99));
    }
}

function Foo5() {
    Massiv2();
    document.getElementById("rez51").innerHTML = Mass1;
    document.getElementById("rez52").innerHTML = Mass2;
}

function Foo6() {
    for (i = 0; i < Mass1.length; i++) {
        Mass3[i] = Mass1[i] + Mass2[i]
    }
    document.getElementById("rez6").innerHTML = Mass3;

}

function Foo7() {
    for (i = 0; i < Mass1.length; i++) {
        Mass3[i] = Mass1[i] * Mass2[i]
    }
    document.getElementById("rez7").innerHTML = Mass3;

}

function Foo8() {
    for (i = 0; i < Mass1.length; i++) {
        if (Mass1[i] > Mass2[i]) {
            Mass3[i] = Mass1[i]
        } else {
            Mass3[i] = Mass2[i]
        }
    }
    document.getElementById("rez8").innerHTML = Mass3;

}

function Massiv1() {
    Mass = [];
    var A = document.getElementById("9").value;
    for (i = 0; i < A; i++) {
        Mass.push(randomInteger(0, 99));
    }
}

function Foo9() {
    Massiv1();
    document.getElementById("rez9").innerHTML = Mass;
}

function Foo10() {
    V = Mass[1]
    P = Mass[4]
    Mass[4] = V
    Mass[1] = P
    document.getElementById("rez10").innerHTML = Mass;
}

function Foo11() {
    V = Mass[document.getElementById("6").value - 1]
    P = Mass[document.getElementById("7").value - 1]
    Mass[document.getElementById("6").value - 1] = P
    Mass[document.getElementById("7").value - 1] = V
    document.getElementById("rez11").innerHTML = Mass;
}


function Foo12() {
    V = Mass[2]
    P = getMaxOfArray(Mass)
    for (i = 0; i < Mass.length; i++) {
        if (Mass[i] == P) {
            var j = i
            break;
        }
    }
    Mass[2] = P
    Mass[j] = V
    document.getElementById("rez12").innerHTML = Mass;
}

function Foo13() {
    V = Mass[0]
    P = getMinOfArray(Mass)
    for (i = 0; i < Mass.length; i++) {
        if (Mass[i] == P) {
            var j = i
            break;
        }
    }
    Mass[0] = P
    Mass[j] = V
    document.getElementById("rez13").innerHTML = Mass;
}

function MassivRost() {
    Mass = [];
    for (i = 0; i < 15; i++) {
        Mass.push(randomInteger(150, 210));
    }
}

function Foo14() {
    MassivRost()
    document.getElementById("rez14").innerHTML = Mass;
}

function Сортировка_пузырьком(Mass) {
    var I = 0
    var J = 0
    for (var i = 0, I = Mass.length - 1; i < I; i++) {
        for (var j = 0, J = I - i; j < J; j++) {
            if (Mass[j] > Mass[j + 1]) {
                var swap = Mass[j];
                Mass[j] = Mass[j + 1];
                Mass[j + 1] = swap;
            }
        }
    }
    return Mass;
}

function Foo15() {
    Mass.push(document.getElementById("8").value)
    Сортировка_пузырьком(Mass)
    document.getElementById("rez15").innerHTML = Mass;
}