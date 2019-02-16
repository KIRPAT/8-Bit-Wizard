int count = 0;
int joyPin1 = 0;
int joyPin2 = 1;

int x = 0;
int y = 0;

void setup() {
  Serial.begin(9600);
}

int treatValue(int data) {
  return (data * 9 / 1024) + 48;
}
void loop() {
  x = analogRead(joyPin1);
  delay(100);
  y = analogRead(joyPin2);

  Serial.print("x: ");
  Serial.println(treatValue(x));
  
  /*if(count == 10000)
    count = 0;
  Serial.print("Teste: ");
  Serial.println(count);
  delay(1000);*/
 }
