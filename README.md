# Escolha Restaurante

- 1 - Todos os dados são salvos em memória utlizando uma classe Singleton que simula um banco de dados. Quando um singleton é inicializado é criado uma instanca desse objeto, nos próximos acessos é retornado a mesma instância.

Pode ser visto em: EscolhaRestaurante/EscolhaRestauranteCore/Data/FakeDB.cs

- 2 - Todos os casos abordados fora resolvidos com consultas LINQ.

- 2.1 - Um profissional só pode votar em um restaurante por dia: Há uma consulta LINQ que verifica se ja existe um voto de uma mesma pessoa e restaraunte para o mesmo dia.
 
 Pode ser visto em: EscolhaRestaurante/EscolhaRestauranteCore/Data/FakeDB.cs no método AddVote
 
- 2.2 - O mesmo restaurante não pode ser escolhido mais de uma vez durante a semana: Foi resolvido com duas consultas LINQ, a primeira  busca todo o restaurante mais votado, ordenado pelo mais recente. A segunda consulta busca todos os restarauntes que não tenham sido escolhidos na semana, se for domingo traz todos. Apois isso é buscado o mais votado na lista dos disponíveis.

Pode ser visto em: EscolhaRestaurante/EscolhaRestauranteCore/Data/FakeDB.cs no método GetRestaurantByDate

- 3 -  Há uma segunda pagina que informa qual o restaurante foi escolhido para aquele dia.


PS.: Todas as lógicas se encontram dentro do projeto EscolhaRestauranteCore (EscolhaRestaurant/EscolhaRestauranteCore/)
