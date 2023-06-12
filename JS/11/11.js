var employees=[]
employees[0]={Имя: "George", Оценка1: 3,Оценка2: 5,Оценка3: 4}
employees[1]={Имя: "Edward", Оценка1: 4,Оценка2: 2,Оценка3: 3}
employees[2]={Имя: "Christine",Оценка1: 4 ,Оценка2: 4,Оценка3: 4}
employees[3]={Имя: "Sarah", Оценка1: 5,Оценка2: 5,Оценка3: 3}
function Foo()
{
    var otv = " ";
for(var i = 0 ; i<4 ;i++)
{
    otv += JSON.stringify(employees[i]) + "</br>"
}
document.getElementById("rez").innerHTML = otv

}
function Foo1()
{
    employees.sort(function(a, b)
    {
        var nameA=a.Имя.toLowerCase(), nameB=b.Имя.toLowerCase()
        if (nameA < nameB) //сортируем строки по возрастанию
          return -1
        if (nameA > nameB)
          return 1
        return 0 // Никакой сортировки
        })
        var otv = " ";
        for(var i = 0 ; i<4 ;i++)
        {
            otv += JSON.stringify(employees[i]) + "</br>"
        }
        document.getElementById("rez").innerHTML = otv

}
function Foo2()
{
for(i = 0;i < 4; i++)
{
    employees[i].Итог = employees[i].Оценка1 + employees[i].Оценка2 + employees[i].Оценка3;
}
employees.sort(function(a, b){
  return a.Итог-b.Итог
})

var otv = " ";
for(var i = 0 ; i<4 ;i++)
{
    otv += JSON.stringify(employees[i]) + "</br>"
}
document.getElementById("rez").innerHTML = otv
}
