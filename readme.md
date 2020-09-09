# Teste prático Tolentinos

O teste foi desenvolvido utilizando as seguintes tecnologias:
- **.Net Core 3.1**
- **MariaDB** para persistência de dados
- **Redis** como cache

# Como executar
Após clonar o repositório, acessar a pasta do projeto e configurar as chaves de acesso da AWS, você poderá executar o projeto através destes dois métodos:

## Utilizando Visual Studio
- Abra o arquivo de solução "Tolentinos - Vinicius.sln" utilizando o Visual Studio
- Selecione o projeto "docker-compose" e defina como "Projeto de Inicialização"
- Pressione F5 ou vá em Depurar -> Iniciar Depuração
- Um navegador será iniciado já na página inicial do Swagger

## Utilizando o  terminal
- Execute o comando `docker-compose up -d` na pasta raiz da solução
- Acesse `http://localhost:5000` pelo navegador de sua preferência

Em ambos os casos, após iniciar o projeto, o mesmo executará as migrações e populará o BD com dados de teste