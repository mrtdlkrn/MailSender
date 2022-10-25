using System;
using System.Collections.Generic;
using System.Text;
using MailSender.Concrete;
using MailSender.Model;
using Newtonsoft.Json;
using RabbitMQ.Client;

namespace MailServerProject
{
    public class MessageProcessor : DefaultBasicConsumer
    {
        private readonly IModel _channel;

        public MessageProcessor(IModel channel)
        {
            _channel = channel;
        }

        public override void HandleBasicDeliver(string consumerTag, ulong deliveryTag, bool redelivered, string exchange, string routingKey, IBasicProperties properties, byte[] body)
        {
            //Console.WriteLine($"Consuming Message");
            //Console.WriteLine(string.Concat("Message received from the exchange ", exchange));
            //Console.WriteLine(string.Concat("Consumer tag: ", consumerTag));
            //Console.WriteLine(string.Concat("Delivery tag: ", deliveryTag));
            //Console.WriteLine(string.Concat("Routing tag: ", routingKey));
            //Console.WriteLine(string.Concat("Message: ", Encoding.UTF8.GetString(body)));

            string message = Encoding.UTF8.GetString(body);
            Console.Write("Mail gönderiliyor----\t");

            MailEngine mailMotoru = new MailEngine();

            MailInfo mailBilgi = JsonConvert.DeserializeObject<MailInfo>(message);

            MailSendResult mailGonderimSonuc = mailMotoru.MailGonder(mailBilgi);

            if(mailGonderimSonuc.Success)
                Console.WriteLine("----Mail gönderildi.");
            else
                Console.WriteLine("----Mail gönderimi başarısız.");

            _channel.BasicAck(deliveryTag, false);

        }
    }
}
