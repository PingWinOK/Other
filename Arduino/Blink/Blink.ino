/*
 * ESP8266 (NodeMCU) Handling Web form data basic example
 * https://circuits4you.com
 */
#include <MQTT.h>
#include <PubSubClient.h>
#include <ESP8266WiFi.h>
#include <WiFiClient.h>
#include <ESP8266WebServer.h>

const char MAIN_page[] PROGMEM = R"=====(
<!DOCTYPE html>
<html>
<body>

<h2>Circuits4you<h2>
<h3> HTML Form ESP8266</h3>

<form action="/action_page">
  Введите текст:<br>
  <input type="text" name="Text" value=" ">
  <br><br>
  <input type="submit" value="Submit">
  
</form> 

</body>
</html>
)=====";

//SSID and Password of your WiFi router
const char *ssid =  "TP-LINK_4E10";  // Имя вайфай точки доступа
const char *password =  "58655139"; // Пароль от точки доступа
const char *mqtt_server = "h601599c.us-east-1.emqx.cloud"; // Имя сервера MQTT
const int mqtt_port = 15282; // Порт для подключения к серверу MQTT
const char *mqtt_user = "Danil"; // Логин от сервер
const char *mqtt_pass = "123"; // Пароль от сервера

ESP8266WebServer server(80); //Server on port 80

void callback(const MQTT::Publish& pub)
{
  String payload = pub.payload_string();
  String topic = pub.topic();
  
  Serial.print(pub.topic()); // выводим в сериал порт название топика
  Serial.print(" => ");
  Serial.println(payload); // выводим в сериал порт значение полученных данных

  // проверяем из нужного ли нам топика пришли данные 
  if(topic == "text/text")
  {
     Serial.println("test/2 OK"); // выводим в сериал порт подтверждение, что мы получили топик test/2
  }
}
WiFiClient wclient;      
PubSubClient client(wclient, mqtt_server, mqtt_port);
//===============================================================
// This routine is executed when you open its IP in browser
//===============================================================
void handleRoot() {
 String s = MAIN_page; //Read HTML contents
 server.send(200, "text/html", s); //Send web page
}
//===============================================================
// This routine is executed when you press submit
//===============================================================
void handleForm() {
 String Text = server.arg("Text"); 

 client.publish("text/text",Text);
 Serial.print("Ваше сообщение:");
 Serial.println(Text);
 
 String s = "<a href='/'> Назад </a>";
 server.send(200, "text/html", s); //Send web page
}
//==============================================================
//                  SETUP
//==============================================================
void setup(void){
  Serial.begin(9600);
  
  WiFi.begin(ssid, password);     //Connect to your WiFi router
  Serial.println("");

  // Wait for connection
  while (WiFi.status() != WL_CONNECTED) {
    delay(500);
    Serial.print(".");
    
  }
    if (WiFi.status() == WL_CONNECTED) 
  {
    if (!client.connected()) 
    {
      Serial.println("Connecting to MQTT server");
      if (client.connect(MQTT::Connect("arduinoClient2")
                         .set_auth(mqtt_user, mqtt_pass))) 
      {
        Serial.println("Connected to MQTT server");
        client.set_callback(callback);
        client.subscribe("text/text"); // подписывааемся по топик с данными для светодиода
      } 
      else 
      {
        Serial.println("Could not connect to MQTT server");   
      }
    }

    if (client.connected())
    {
      client.loop();
    }
  }
  //If connection successful show IP address in serial monitor
  Serial.println("");
  Serial.print("Connected to ");
  Serial.println("WiFi");
  Serial.print("IP address: ");
  Serial.println(WiFi.localIP());  //IP address assigned to your ESP
 
  server.on("/", handleRoot);      //Which routine to handle at root location
  server.on("/action_page", handleForm); //form action is handled here

  server.begin();                  //Start server
  Serial.println("HTTP server started");
}

//==============================================================
//                     LOOP
//==============================================================
void loop(void){
  server.handleClient();          //Handle client requests
  client.set_callback(callback);
}
