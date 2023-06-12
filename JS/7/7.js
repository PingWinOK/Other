function Foo1() {
    var A = document.getElementById("1").value
    var count = 0;
    A = A.toString()
    var pos = A.indexOf('а');

    while (pos !== -1) {
        count++;
        pos = A.indexOf('а', pos + 1);
    }
    document.getElementById("rez").innerHTML = count
}

function Foo2() {
    var A = document.getElementById("2").value
    var Str = '';
    for (var i = 0; i < A.length; i++) {
        Str += A[i] + A[i]
    }
    document.getElementById("rez1").innerHTML = Str

}

function Foo3() {
    var A = document.getElementById("3").value
    var l = 0
    var p = 0
    var a = 0
    var z = 0
    var skob = []
    var i = 0
    var j = 1
    for (var i = 0; i < A.length; i++) {
        if (A[i] == "(") {
            l += 1
            skob[a] = A[i]
            a++
        }
        if (A[i] == ")") {
            p += 1
            skob[a] = A[i]
            a++
        }
    }

    if (p < l) {
        document.getElementById("rez3").innerHTML = "Количество скобок:" + (l - p)
        document.getElementById("rez2").innerHTML = "Нет"
    } else if (p > l) {
        for (var i = 0; i < skob.length; i++) {
            if (skob[i] == "(") {
                z = 0
            } else {
                z = i
            }
        }
        document.getElementById("rez3").innerHTML = "Позиция первой скобки:" + i
        document.getElementById("rez2").innerHTML = "Нет"
    } else {
        document.getElementById("rez2").innerHTML = "Да"
    }
}

function Foo4() {
    var k = document.getElementById("4").value
    var A = document.getElementById("5").value
    var Mass = []
    var j = 0
    parseInt(k)
    for (var i = 0; i < A.length; i++) {
        if (i == k - 1) {
            Mass[i] = A[A.length - 1]
        } else {
            Mass[i] = A[j]
            j++
        }
    }
    Mass[Mass.length] = A[A.length - 1]
    document.getElementById("rez4").innerHTML = Mass
}