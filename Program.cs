using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace addClient
{
    class Program
    {
        static void Main(string[] args)
        {
            AddClient x = new AddClient();
            x.add();
        }
    }

    class AddClient
    {    
        int op,num = 0, op2 = 0;
        StreamWriter archivo,amountOfClient,newHtml,newCSS;
        StreamReader reader,amountClient;
        string[]  client = new string [9],datType = new string [9];
        string contenido,contenidoCss,data;

        public static void openit(string x){
           System.Diagnostics.Process.Start("cmd", "/C start" + " " + x);
         }
        public string dat(string txt){
            Console.Write(txt);
            string z = Console.ReadLine();
            
            return z;
        }
        public void saveDat(){

        for (int i = 0; i < datType.Length; i++)
        {
            if (i == 0){
                archivo.WriteLine("-Cliente "+ client[1].ToString()+"\n");
            }
                archivo.WriteLine(datType[i].ToString()+client[i].ToString());
        }

        archivo.WriteLine("• Cliente numero :"+num);
        archivo.Close();
        
        Console.WriteLine("\n\tEl cliente se guardo exitosamente.\n\n\t4)Regresar al Menu principal\n\t5)Añadir Otro Cliente\n");
        Console.Write("\n\tTu opcion: ");
        op2 = int.Parse(Console.ReadLine());
        
        }
        public void readDat(){
            Console.Clear();
            reader = new StreamReader("Clients.txt");
             try
            {
                    string line;
                    string title ="Datos De Los Clientes\n";
                    Console.WriteLine(title);
                    while ((line = reader.ReadLine()) != null)
                    {
                        Console.WriteLine(line);
                    }
                    reader.Close();
                }
            catch (Exception)
            {
                Console.WriteLine("\tEl archivo no se puede leer");
            }

             Console.WriteLine("\n\tEl registro se mostro exitosamente.\n\n\t4)Regresar al Menu principal\n");
            Console.Write("\n\tTu opcion: ");
            op2 = int.Parse(Console.ReadLine());
        }
        public void fileHtml(){
            if(Directory.Exists("HTML")==false){
                Directory.CreateDirectory("HTML");
            }
            if(File.Exists("HTML\\ClientTable.html")==false){
                File.WriteAllText("HTML\\ClientTable.html",contenido);
            newHtml.WriteLine(contenido);
            newCSS.WriteLine(contenidoCss);
            }else{
            newHtml.WriteLine(data);
            }
           
            newHtml.Close();
            newCSS.Close();

                // File.WriteAllText("HTML\\ClientTable"+num+".html",contenido);
                File.WriteAllText("HTML\\ClientTable.css",contenidoCss);
        }
        public void file(){
            StreamWriter n;
             n = new StreamWriter("numOfClient.txt");
             n.WriteLine(0);
             n.Close();
        }
        public void validDat(string txt){
           for(var i = 0; i< client.Length; i++){
            if (client[i] == "")
            {
                do
                {
                client[i] = dat(txt);
                    
                } while (client[i] == "");
            }
           }
       }
        public void saveClientNum(){
            amountOfClient = new StreamWriter("numOfClient.txt");
            amountOfClient.WriteLine(num);
            amountOfClient.Close();

        }
        public void readClientNum(){
            amountClient = new StreamReader("numOfClient.txt");
              try
            {
                    int lin;
                    while ((lin = int.Parse(amountClient.ReadLine())) != -1)
                    {
                        num = Convert.ToInt16( lin);
                        amountClient.Close();
                    }
                   

                }
            catch (Exception)
            {
                Console.WriteLine();
            }
        }
        public void add(){
            if(File.Exists("numOfClient.txt")==false){
                file();
            }
            do
            {
            Console.Title ="Añadir Clientes! "; 
            Console.WindowWidth = 50;
            Console.WindowHeight = 30;
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();
                
            readClientNum();

            Console.WriteLine("\t\t---------------------");
            Console.WriteLine("\t\t   Añadir Clientes");
            Console.WriteLine("\t\t---------------------\n");
            Console.WriteLine("\t\tNumero De Clientes Añadido :"+num);
            Console.Write("\n\t\t1) Añadir Nuevo Cliente\n\t\t2) Mostrar Clientes Añadidos\n\t\t3) Abrir En HTML\n\t\t4) Cerrar Programa\n\n\t\tTu opcion: ");
            op = int.Parse(Console.ReadLine());
            
            if (op == 3){
                openit("ClientTable.html");
                op2 = 4;

                }
            if (op == 4){
                    System.Environment.Exit(-1);
                }
       
            if(op == 1){
                do
                {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();

            archivo = new StreamWriter("Clients.txt",true);
            newHtml = new StreamWriter("ClientTable.html",true);
            newCSS = new StreamWriter("ClientTable.css",true);

            num = num +1;
            saveClientNum();

            Console.WriteLine("\t\t---------------------");
            Console.WriteLine("\t\t   Datos del cliente");
            Console.WriteLine("\t\t---------------------\n");

            client[0] = dat("* Digite Su Numero De Cedula : ");
            validDat("* Digite Su Numero De Cedula : ");
            client[1] = dat("* Digite Su Nombre : ");
            validDat("* Digite Su Nombre : ");
            client[2] = dat("* Digite Su Apellido : ");
            validDat("* Digite Su Apellido : ");
            client[3] = dat("* Digite Su Genero : ");
            validDat("* Digite Su Genero : ");
            client[4] = dat("* Digite Su Fecha De Nacimiento : ");
            validDat("* Digite Su Fecha De Nacimiento : ");
            client[5] = dat("* Digite Su Correo : ");
            validDat("* Digite Su Correo : ");
            client[6] = dat("* Digite Su Telefono : ");
            validDat("* Digite Su Telefono : ");
            client[7] = dat("* Digite Su Celular : ");
            validDat("* Digite Su Celular : ");
            client[8] = dat("* Digite Su Carrera : ");
            validDat("* Digite Su Carrera : ");
            Console.WriteLine("\nPresiona Cualquier Tecla Para Continuar...\n");
            String Cadena = Console.ReadLine();
            archivo.WriteLine(Cadena);
            
            datType[0] ="• Cedula: ";
            datType[1] ="• Nombre: ";
            datType[2] ="• Apellido: ";
            datType[3] ="• Genero : ";
            datType[4] ="• Fecha de nacimiento: ";
            datType[5] ="• Correo: ";
            datType[6] ="• Telefono: ";
            datType[7] ="• Celular: ";
            datType[8] ="• Carrera: ";
            
            data ="<!DOCTYPE html>"+ "<html lang='en'>"+ "<head>"+ "<meta charset='UTF-8'>"+ "<link rel='stylesheet' href='ClientTable.css'>"+"</head>"+ "<body>"+ "<table class='table' id='clientsTable'>"+ "<thead>"+ "<tr>"+ "<th>Codigo</th>"+ "<th>Nombre</th>"+ "<th>Apellido</th>"+ "<th>Cedula</th>"+ "<th>Fecha De Nacimiento</th>"+ "<th>Genero</th>"+ "<th>Celular</th>"+ "<th>Telefono</th>"+ "<th>Correo</th>"+ "<th>Carrera</th>"+"</tr>"+"</thead>"+ "<tbody>"+ "<td>"+num+"</td>"+ "<td>"+client[1]+"</td>"+ "<td>"+client[2]+"</td>"+ "<td>"+client[0]+"</td>"+ "<td>"+client[4]+"</td>"+ "<td>"+client[3]+"</td>"+ "<td>"+client[7]+"</td>"+ "<td>"+client[6]+"</td>"+ "<td>"+client[5]+"</td>"+ "<td>"+client[8]+"</td>"+"</tbody>"+"</table>"+"</body>"+"</html>";
            contenido ="<!DOCTYPE html>"+ "<html lang='en'>"+ "<head>"+ "<meta charset='UTF-8'>"+ "<meta name='viewport' content='width=device-width, initial-scale=1.0'>"+ "<meta http-equiv='X-UA-Compatible' content='ie=edge'>"+ "<title>Clients Table</title>"+ "<link rel='stylesheet' href='ClientTable.css'>"+ "<link rel='stylesheet' href='https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css' integrity='sha384-BVYiiSIFeK1dGmJRAkycuHAHRg32OmUcww7on3RYdg4Va+PmSTsz/K68vbdEjh4u' crossorigin='anonymous'>"+"</head>"+ "<body>"+ "<div class='container'>"+ "<h2 class='titulo'>Datos De Los Clientes</h2>"+ "<br>"+ "<table class='table' id='clientsTable'>"+ "<thead>"+ "<tr>"+ "<th>Codigo</th>"+ "<th>Nombre</th>"+ "<th>Apellido</th>"+ "<th>Cedula</th>"+ "<th>Fecha De Nacimiento</th>"+ "<th>Genero</th>"+ "<th>Celular</th>"+ "<th>Telefono</th>"+ "<th>Correo</th>"+ "<th>Carrera</th>"+"</tr>"+"</thead>"+ "<tbody>"+ "<td>"+num+"</td>"+ "<td>"+client[1]+"</td>"+ "<td>"+client[2]+"</td>"+ "<td>"+client[0]+"</td>"+ "<td>"+client[4]+"</td>"+ "<td>"+client[3]+"</td>"+ "<td>"+client[7]+"</td>"+ "<td>"+client[6]+"</td>"+ "<td>"+client[5]+"</td>"+ "<td>"+client[8]+"</td>"+"</tbody>"+ "<tbody>"+"</tbody>"+"</table>"+"</div>"+ "<script src='https://code.jquery.com/jquery-3.4.1.js'></script>"+ "<script src='https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js' integrity='sha384-Tc5IQib027qvyjSMfHjOMaLkfuWVxZxUPnCJA7l2mCWNIpG9mGCD8wGNIcPD7Txa' crossorigin='anonymous'></script>"+"</body>"+"</html>";
            contenidoCss ="* {	box-sizing: border-box;	color: white;	font-family: monospace, cursive;}"+"body {	background-image: linear-gradient(to top, #a8edea 0%, #273081 100%);	background-attachment: fixed;	background-repeat: no-repeat;}"+".container {	background-color: transparent;}"+"div h2 {	text-align: center;	font-family: serif;	font-size: -webkit-xxx-large;}"+"td {	color: black;}"+"tr th,td,h3 {	text-align: center;}"+".table {	width: 450px;	height: 150px;	border-radius: 5px;	margin: 2% auto;	box-shadow: 0 9px 50px hsla(20, 67%, 75%, 0.31);	padding: 2%;	background-color: transparent;}"+"table thead :hover {	border-bottom: 3px solid wheat;	box-shadow: 0px 1px 9px -3.5px wheat;}"+"i.id,i.name,i.country,i.birthday,i.email {	position: relative;	right: 176px;	top: 42px;	border-right: 1px solid #0000005e;	color: #273081;}";

            Console.Clear();
            saveDat();
            fileHtml();

                }while (op2 == 5);
            } 

            if(op == 2){
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();
                
            readDat();
            }

            }while (op2 == 4);
        }
    }
}

              