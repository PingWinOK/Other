# Generated by Django 4.0.6 on 2022-08-09 18:31

from django.db import migrations, models


class Migration(migrations.Migration):

    initial = True

    dependencies = [
    ]

    operations = [
        migrations.CreateModel(
            name='Artists',
            fields=[
                ('id', models.BigAutoField(auto_created=True, primary_key=True, serialize=False, verbose_name='ID')),
                ('UserId', models.IntegerField(default=0)),
                ('CheckId', models.IntegerField(default=0)),
                ('ProductName', models.CharField(default='NULL', max_length=128)),
                ('ProductCost', models.IntegerField(default=0)),
                ('MerchantName', models.CharField(default='NULL', max_length=128)),
                ('MCC', models.IntegerField(default=0)),
            ],
            options={
                'verbose_name': 'Покупатель',
                'verbose_name_plural': 'Покупатели',
            },
        ),
    ]
