function Planeta(name, mass, diam) {
    this.name = name;
    this.mass = mass;
    this.diam = diam;
}
var n = 1, g = 0;
var Planeti = [];


function SozPlanetu() {
    var Per = [];
    var t,t1 = ""
    var r = document.getElementsByTagName("input");
    for (i = 0; i < r.length; i++) {
        Per[i] = r[i].value;
    }
    for (i = 0; i < r.length; i++) 
    {
        t1 += ",Per[" + i + "]"
    }
        t1 = t1.slice(1);
        t = "Planeti[n] = new Planeta(" + t1 + ")"
        eval(t);

    n++

    document.getElementById('1').value = "Введите название планеты";
    document.getElementById('2').value = "Введите массу планеты";
    if(g == 1)
    {
        document.getElementById('3').value = "Введите плотность планеты";
    }
    else
    {
        document.getElementById('3').value = "Введите диаметр планеты";
    }

}

function ydalitdiam() 
{
    delete Planeta.diam;
    document.getElementById('3').value = "";
}
function dobavitPlot()
{
    Planeta.plot = 5.5153
    document.getElementById('3').value = "Введите плотность планеты";
    g = 1
}
function vivod()
{
    var otv = '';
    for(var i in Planeti)
    {
        otv += "<p>Название планеты: "+Planeti[i].name + "</br>";
        otv += "Масса планеты: "+Planeti[i].mass + "</br>";
        if(g == 1)
        {
            otv += "Плотность планеты: "+Planeti[i].diam + "</br></p>";
        }
        else
        {
            otv += "Диаметр планеты: "+Planeti[i].diam + "</br></p>";
        }
    }
    document.getElementById("rez").innerHTML = otv;
}
function aler()
{
    var otv = '';
    for(var i in Planeti)
    {
        otv += "Название планеты: "+Planeti[i].name + "\n";
        otv += "Масса планеты: "+Planeti[i].mass + "\n";
        if(g == 1)
        {
            otv += "Плотность планеты: "+Planeti[i].diam + "\n\n";
        }
        else
        {
            otv += "Диаметр планеты: "+Planeti[i].diam + "\n\n";
        }
    }
    alert(otv);
}