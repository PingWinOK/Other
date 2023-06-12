from django.shortcuts import render
from django.http import HttpResponse
from .models import Artists


# импорт модели Artists


def index(request):
    Human = Artists.objects.all()
    return render(request, "index.html", {'Human': Human})
