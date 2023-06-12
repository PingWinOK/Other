FROM python:latest
ENV PYTHONDONTWRITEBYTECODE=1
ENV PYTHONUNBUFFERED=1
WORKDIR /Server
COPY requirements.txt /Server/
RUN pip install -r requirements.txt
COPY . /Server/
