function Foo1()
{
    var x = 10;
    function foo() {
        var y = x + 5;
        return y;
    }
    function bar() {
        var x = 2;
        return foo();
    }
    foo();
    document.getElementById("rez1").innerHTML = bar();

}
function Foo3() {
    var value = 0;
    function f()
    {
        if (1)
        {
        value = true;
        }
        else
        {
            var value = false;
        }
        alert(value);
    }
    f();
}
function Foo2() {
    var result = [];
    for (let/*<- גלוסעמ var*/ i = 0; i < 5; i++)
    {
        result[i] = function ()
        {
            console.log(i);
        };
    }
    result[0]();
    result[1]();
    result[2]();
    result[3]();
    result[4]();



}
function Foo4()
{
    function test()
    {
        alert(window);
        var window = 5;
        alert(window);
    }
    document.getElementById("rez4").innerHTML = test();


}
function Foo5()
{
    var a = 5(function (){alert(a)})()

}