# DevFreela - Uma API para contrato de freelancers.

<p align="center">
<img loading="lazy" src="http://img.shields.io/static/v1?label=STATUS&message=EM%20DESENVOLVIMENTO&color=GREEN&style=for-the-badge"/>
</p>

## Descrição
O DevFreela é uma API projetada para facilitar o gerenciamento de projetos entre clientes e desenvolvedores freelancers. Com ela, é possível criar, atualizar e acompanhar o progresso de projetos, bem como gerenciar pagamentos e interações entre as partes envolvidas. A solução oferece uma interface prática e eficiente para conectar clientes a freelancers, promovendo a organização e o acompanhamento de trabalhos de maneira estruturada e segura.

## Abordagem de Desenvolvimento

Com o Entity Framework Core, utilizou-se a abordagem ```Code First```, no qual primeiramente foram definidas as entidades que a aplicação interagiria, para que somente em um segundo momento o banco de dados fosse criado.

## Arquitetura

Foi definido que o projeto segue os princípios da arquitetura limpa, separando as responsabilidades, visando escalabilidade através da facilidade no gerenciamento de mudanças, reutilização de código e integridade de dados.

- **API**: Camada responsável por expor os endpoints da Web API.
- **Application**: Implementa os casos de uso e a lógica de aplicação.
- **Core**: Contém as entidades e interfaces principais do domínio.
- **Infrastructure**: Implementação da infraestrutura, como repositórios e comunicação com o banco de dados.
- **Tests**: Projetos de testes unitários e de integração, garantindo a qualidade e o funcionamento correto da aplicação.

## Tecnologias Utilizadas

O projeto utiliza as seguintes tecnologias e padrões:

- **.NET 8**: Framework principal para o desenvolvimento da aplicação.
- **Padrão Repository**: Padrão que abstrai o acesso aos dados, centralizando as operações em um repositório.
- **Padrão Result**: Padrão que define uma forma explícita e clara de expressar erros no código.
- **Padrão CQRS**:(Command Query Responsibility Segregation) Padrão utilizado para separar as responsabilidades de leitura e escrita nos bancos de dados.
- **MediatR**: Biblioteca de código aberto que ajuda a implementar o padrão de design comportamental "mediator" e "CQRS"
- **xUnit**: Framework de testes unitários utilizado para garantir a qualidade do código.
- **Entity Framework Core**: ORM (Object-Relational Mapper) utilizado para comunicação com o banco de dados.
- **SQL Server**: Banco de dados relacional.


Este README fornece uma visão geral do projeto, tecnologias e arquitetura utilizados.