
using RabbitMQ.Client;
using System.Text;

//define a conexão que será aberta
var factory = new ConnectionFactory()
    {
    //url da conexão usuário senha etc
        HostName = "localhost"
    };

//instancia a conexão e abre
using (var connection = factory.CreateConnection())
    //abre um canal onde sera definida a criação das filas e pulicar a msg
using (var channel = connection.CreateModel()) {
    channel.QueueDeclare(
            queue:"msg_01",
            durable:false,
            exclusive:false,
            autoDelete:false,
            arguments:null
        );

    string msg = "ola mundo mqtt ";
    //converte a msg em array de bits
    var _body = Encoding.UTF8.GetBytes(msg);
    //publicação da msg
    channel.BasicPublish(
            exchange:"",
            routingKey: "msg_01",
            basicProperties:null,
            body: _body
        );
        Thread.Sleep(1000);
    
}
Console.ReadKey();