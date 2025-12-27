# Resumo Didático — Organização, Semântica e Boas Práticas em C#

Este projeto aborda conceitos fundamentais da linguagem C# com foco em **organização de código, semântica, encapsulamento e boas práticas de orientação a objetos**, aplicados em exemplos simples de console.

## Organização do Código

Em C#, o código é estruturado em **tipos** (como classes e records) que representam responsabilidades bem definidas. Cada classe deve encapsular um conceito do domínio, evitando misturar lógica de controle, regras de negócio e entrada/saída no mesmo local. O método `Main` atua apenas como ponto de entrada da aplicação, coordenando o fluxo geral do programa.

Uma boa organização favorece:

* Leitura e manutenção do código
* Separação clara de responsabilidades
* Facilidade de evolução e testes

## Classes e Encapsulamento

A `class` é um tipo por referência usado quando a **identidade do objeto** importa e quando há **estado mutável controlado**. Um princípio central é o **encapsulamento**, que consiste em proteger os dados internos do objeto e permitir acesso apenas por meio de métodos bem definidos.

O uso de atributos privados garante que regras importantes (como validações) não sejam burladas por código externo. Métodos públicos representam as ações permitidas sobre o objeto.

## Records e Semântica de Valor

O `record` é um tipo orientado a dados, projetado para representar **informações imutáveis** cujo significado está nos valores que carregam. Diferentemente de classes, records possuem **comparação por valor**, o que os torna adequados para objetos de transferência de dados, resultados de cálculos ou entidades conceituais simples.

A escolha entre `class` e `record` deve considerar a semântica do problema: identidade e comportamento favorecem classes; dados e significado favorecem records.

## Imutabilidade e Segurança

Imutabilidade reduz efeitos colaterais e torna o código mais previsível. Em C#, isso pode ser alcançado de diferentes formas, como inicialização única de propriedades ou ausência de métodos que alterem o estado após a criação do objeto. Esse conceito é especialmente importante em sistemas maiores e em cenários concorrentes.

## Controle de Fluxo e Interação com o Usuário

Estruturas de repetição permitem que o programa continue em execução até que uma condição explícita de saída seja atendida. A validação de entradas do usuário é essencial para evitar erros de execução e garantir que apenas dados válidos sejam processados. O uso de decisões condicionais centraliza regras e torna o comportamento do programa claro e previsível.

## Boas Práticas Gerais

* Manter atributos sensíveis privados
* Expor comportamento por métodos, não por dados
* Validar entradas antes de processá-las
* Usar nomes claros e coerentes com o domínio
* Priorizar legibilidade e simplicidade

## Conclusão

Os conceitos trabalhados demonstram como C# incentiva um design mais seguro e expressivo por meio de encapsulamento, tipagem clara e semântica bem definida. Aplicar essas práticas desde exercícios iniciais contribui para a construção de código mais robusto, compreensível e alinhado com princípios de engenharia de software.
