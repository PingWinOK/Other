#include <ESP8266WiFi.h>
#include <WiFiClient.h>
#include <ESP8266WebServer.h>
#include <ESP8266mDNS.h>

MDNSResponder mdns;

// Настройки Wi-Fi
const char *ssid =  "TP-LINK_4E10";  // Имя вайфай точки доступа
const char *password =  "58655139"; // Пароль от точки доступа

//byte arduino_mac[] = { 0xDE, 0xED, 0xBA, 0xFE, 0xFE, 0xED };
IPAddress ip(192,168,0,35);
IPAddress gateway(192,168,0,1);
IPAddress subnet(255,255,255,0);

ESP8266WebServer server(80);

int D2_pin = 2;

void setup(void)
{
  // preparing GPIOs

  pinMode(D2_pin, OUTPUT);
  digitalWrite(D2_pin, LOW);

  delay(100);
  Serial.begin(115200);
  WiFi.begin(ssid, password);
  WiFi.config(ip, gateway, subnet);
  
  Serial.println("");

  // Ожидание подключения 
  while (WiFi.status() != WL_CONNECTED) 
  {
    delay(500);
    Serial.print(".");
  }
  
  Serial.println("");
  Serial.print("Connected to ");
  Serial.println(ssid);
  Serial.print("IP address: ");
  Serial.println(WiFi.localIP());
  
  if (mdns.begin("esp8266", WiFi.localIP())) 
  {
    Serial.println("MDNS responder started");
  }
  
 // Обработчик для главной страницы
  server.on("/", []()
  {
    server.send(200, "text/html", webPage());
  });

// Обработчик для кнопки (вкл/выкл)
  server.on("/socket2On", [](){
    digitalWrite(D2_pin, LOW);
    server.send(200, "text/html", webPage());
    delay(100);    
  });
  server.on("/socket2Off", [](){
    digitalWrite(D2_pin, HIGH);
    server.send(200, "text/html", webPage());
    delay(100);
  });  
  server.begin();
  Serial.println("HTTP server started");
}
 
void loop(void)
{
  server.handleClient();
} 

String webPage()
{
  String web; 
  // Заголовок страницы
  web += "<head><meta name=\"viewport\" content=\"width=device-width, initial-scale=1\"/> <meta charset=\"utf-8\"><title>ESP 8266</title><style>button{color:red;padding: 10px 27px;}</style></head>";
  web += "<h1 style=\"text-align: center;font-family: Open sans;font-weight: 100;font-size: 20px;\">ESP8266 Web Server</h1><div>";

  // html код для кнопок вкл\выкл
  web += "<dib style=\"text-align: center;margin-top: 0px;margin-bottom: 5px;\">Введите текст</div>";
  web += "<div style=\"text-align: center;margin: 5px 0px;\"> <input></input></div>";
  web += "<div style=\"text-align: center;margin: 5px 0px;\"> <a href=\"inputtext\"><input>Отправить</input></a>&nbsp</div>";

  // html для кнопки refresh
  web += "<div style=\"text-align:center;margin-top: 20px;\"><a href=\"/\"><button style=\"width:158px;\">REFRESH</button></a></div>";
  
  web += "</div>";
  return(web);
}
