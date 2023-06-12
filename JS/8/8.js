function test() {
    var A = document.getElementById("1").value;
    var r = 0
    var SS = new RegExp("а");
    for (i = 0; i < A.length; i++)
    {
        if (A[i] == " ") 
        {
            i++
            r++
        }
        var t = SS.test(A[i]);
        if (SS.test(A[i]) == true)
        {
            r++
        }
    }
    if (r == A.length) {
        document.getElementById("rez").innerHTML = "True"
    }
    else
    {
        document.getElementById("rez").innerHTML = "False"
    }
}
function Foo2() {
    var A = document.getElementById("2").value;
    var r = A.match(/(?:19|20)\d\d/g);
    var Let = 2020 - r
    document.getElementById("rez1").innerHTML = "Вам " + Let + " лет"
}
