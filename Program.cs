using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ExemploCRUD
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Sistema da Papelaria.");
            int opcao;
            
            BancoDados bd;
            Categoria ct;
            List<Categoria> listacat;

            do{
                Console.WriteLine("Digite uma opção: " + 
                                  "\n1 - Categoria" + 
                                  "\n2 - Produto" + 
                                  "\n3 - Cliente" + 
                                  "\n9 - Sair.");

                opcao = Convert.ToInt16(Console.ReadLine());

                switch (opcao)
                {
                    case 1: 
                        Console.WriteLine("Menu Categoria: " + 
                                          "\n1 - Adicionar." + 
                                          "\n2 - Atualizar." + 
                                          "\n3 - Deletar." + 
                                          "\n9 - Sair.");

                        int opcat;
                        opcat = Convert.ToInt16(Console.ReadLine());
                        
                        switch (opcat)
                        {
                            case 1:
                                Console.Write("Digite a categoria a ser adicionada: ");
                                var Titulo = Console.ReadLine();
                                ct = new Categoria();
                                ct.Titulo = Titulo;
                                bd = new BancoDados();
                                bd.Adicionar(ct);
                                
                                Console.WriteLine("\nCategoria cadastrada com sucesso.\n");

                                break;

                            case 2:
                                bd = new BancoDados();
                                ct = new Categoria();
                                
                                Console.Write("Digite o ID da categoria a ser atualizada: ");
                                int idcat = Convert.ToInt16(Console.ReadLine());
                                 listacat = bd.ListarCategorias(Convert.ToInt16(idcat));

                                if(listacat.Count > 0){
                                    Console.WriteLine();
                                    Console.Write("\nDigite o título da nova categoria: ");
                                    string novacat = Console.ReadLine();
                                    ct.IdCategoria = idcat;
                                    ct.Titulo = novacat;
                                    bd.Atualizar(ct);
                                }
                                else{
                                    Console.WriteLine("\nCategoria não encontrada.");
                                }
                                                              
                                Console.WriteLine("\nCategoria atualizada com sucesso.\n");
                                break;
                            
                            case 3:
                                //fazer deletar.
                                break;
                        }
                        break;
                    
                }
    
            }
            while (opcao != 9);
;
            {
                
            }
            
        }
    }
}

