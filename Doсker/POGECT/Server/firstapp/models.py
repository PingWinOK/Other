from tabnanny import verbose
from django.db import models

class Artists(models.Model):
    UserId = models.IntegerField(default=0)
    CheckId = models.IntegerField(default=0)
    ProductName = models.CharField(max_length=128, default='NULL')
    ProductCost = models.IntegerField(default=0)
    MerchantName = models.CharField(max_length=128, default='NULL')
    MCC = models.IntegerField(default=0)

    def __str__(self):
        return self.MerchantName
    
    class Meta:
        verbose_name = 'Покупатель'
        verbose_name_plural = 'Покупатели'