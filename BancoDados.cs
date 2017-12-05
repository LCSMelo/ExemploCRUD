using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ExemploCRUD
{
    public class BancoDados
    {
        SqlConnection cn;
        SqlCommand comandos;
        SqlDataReader rd;

        //
            /// <summary>
            /// Comando que adiciona dados em "Categoria".
            /// </summary>
            /// <param name="cat">utiliza um parâmetro do tipo booleano.</param>
            /// <returns>não retorna dados.</returns>
        public bool Adicionar(Categoria cat){
            bool rs = false;
            try{
                cn = new SqlConnection();
                cn.ConnectionString = @"Data Source =.\sqlexpress;Initial Catalog=Papelaria; // Informa que os dados de conexão serão do tipo string
                                       User ID = sa; Password = senai@123;";
                cn.Open();
                comandos = new SqlCommand(); //criar comandos
                comandos.Connection = cn; //onde os camandos devem ser executados > conexão "cn"

                comandos.CommandType = CommandType.Text; // indica o tipo de comando, como texto
                comandos.CommandText = "INSERT INTO Categoria(titulo) VALUES(@vt)"; // comando a ser executado com valor do parâmetro @vt indicado a seguir
                comandos.Parameters.AddWithValue("@vt", cat.Titulo);
                
                int r = comandos.ExecuteNonQuery(); // indica que depois da execução ele retonará um valor de número de linhas alteradas.
                if(r > 0)
                    rs = true;

                comandos.Parameters.Clear(); //limpa os parâmetros para a próxima execução
            }
            catch (SqlException se){
                throw new Exception("Erro ao tentar cadastrar." + se.Message);
            }
            catch(Exception ex){
                throw new Exception("Erro inesperado." + ex.Message);
            }
            finally{
                cn.Close();
            }
            return rs;

        }     
        //
            /// <summary>
            /// Comando que atualiza os dados em "Categoria".
            /// </summary>
            /// <param name="cat">Utiliza um parâmetro do tipo booleano.</param>
            /// <returns>Não retorna dados.</returns>
        public bool Atualizar(Categoria cat){
            bool rs = false;
            try{
                cn = new SqlConnection();
                cn.ConnectionString = @"Data Source =.\sqlexpress;Initial Catalog=Papelaria; // Informa que os dados de conexão serão do tipo string
                                       User ID = sa; Password = senai@123;";
                cn.Open();
                comandos = new SqlCommand(); //criar comandos
                comandos.Connection = cn; //onde os camandos devem ser executados > conexão "cn"

                comandos.CommandType = CommandType.Text; // indica o tipo de comando, como texto
                comandos.CommandText = "update categoria set titulo = @vt where idcategoria = @vi"; // comando a ser executado com valor do parâmetro @vt indicado a seguir
                comandos.Parameters.AddWithValue("@vt", cat.Titulo);
                
                int r = comandos.ExecuteNonQuery(); // indica que depois da execução ele retonará um valor de número de linhas alteradas.
                if(r > 0)
                    rs = true;

                comandos.Parameters.Clear(); //limpa os parâmetros para a próxima execução
            }
            catch (SqlException se){
                throw new Exception("Erro ao tentar atualizar." + se.Message);
            }
            catch(Exception ex){
                throw new Exception("Erro inesperado." + ex.Message);
            }
            finally{
                cn.Close();
            }
            return rs;
        }

        //
            /// <summary>
            /// Comando que exclui os dados em "Categoria".
            /// </summary>
            /// <param name="cat">Utiliza um parâmetro do tipo booleano.</param>
            /// <returns>Não retorna dados.</returns>
        public bool Deletar(Categoria cat){
            bool rs = false;
            try{
                cn = new SqlConnection();
                cn.ConnectionString = @"Data Source =.\sqlexpress;Initial Catalog=Papelaria; // Informa que os dados de conexão serão do tipo string
                                       User ID = sa; Password = senai@123;";
                cn.Open();
                comandos = new SqlCommand(); //criar comandos
                comandos.Connection = cn; //onde os camandos devem ser executados > conexão "cn"
                comandos.CommandType = CommandType.Text; // indica o tipo de comando, como texto
                comandos.CommandText = "delete from categoria where idcategoria = @vt"; // comando a ser executado com valor do parâmetro @vt indicado a seguir
                comandos.Parameters.AddWithValue("@vt", cat.IdCategoria);
                
                int r = comandos.ExecuteNonQuery(); // indica que depois da execução ele retonará um valor de número de linhas alteradas.
                if(r > 0)
                    rs = true;

                comandos.Parameters.Clear(); //limpa os parâmetros para a próxima execução
            }
            catch (SqlException se){
                throw new Exception("Erro ao tentar excluir." + se.Message);
            }
            catch(Exception ex){
                throw new Exception("Erro inesperado." + ex.Message);
            }
            finally{
                cn.Close();
            }
            return rs;
        }
        
        //
            /// <summary>
            /// Pesquisa categorias pelo Id.
            /// </summary>
            /// <param name="id">Utiliza um parâmetro do tipo int.</param>
            /// <returns>Retorna uma lista com o resultado dos dados pesquisados.</returns>
        public List<Categoria> ListarCategorias(int id){
            
            List<Categoria> lista = new List<Categoria>();
            try{
                cn = new SqlConnection();
                cn.ConnectionString = @"Data Source = .\sqlexpress;Initial Catalog = Papelaria;
                                        User ID = sa; Password = senai@123;";
                cn.Open();
                comandos = new SqlCommand();
                comandos.Connection = cn;
                comandos.CommandType = CommandType.Text;
                comandos.CommandText = "SELECT * FROM Categoria WHERE idCategoria = @vt";
                comandos.Parameters.AddWithValue("@vt", id);
                rd = comandos.ExecuteReader();

                while (rd.Read()){

                    // Categoria ct = new Categoria(){
                    //         IdCategoria = rd.GetInt32(0),
                    //             Titulo = rd.GetString(1)
                    // };
                    // lista.Add(ct);
                    lista.Add(new Categoria{
                                IdCategoria = rd.GetInt32(0),
                                Titulo = rd.GetString(1)
                                });
                }
                comandos.Parameters.Clear(); //limpa os parâmetros para a próxima execução
            }
            catch (SqlException se){
                throw new Exception("Erro ao tentar listar os dados. " + se.Message);
            }
            catch (Exception ex){
                throw new Exception("Erro inesperado: " + ex.Message);
            }
            finally{
                cn.Close();
            }
            return lista;
        }

        //
            /// <summary>
            /// Pesquisa categorias pelo Título.
            /// </summary>
            /// <param name="titulo">Utiliza um parâmetro do tipo string.</param>
            /// <returns>Retorna uma lista com o resultado dos dados pesquisados.</returns>
        public List<Categoria> ListarCategorias(string titulo){
            
            List<Categoria> lista = new List<Categoria>();
            try{
                cn = new SqlConnection();
                cn.ConnectionString = @"Data Source = .\sqlexpress;Initial Catalog = Papelaria;
                                        User ID = sa; Password = senai@123;";
                cn.Open();
                comandos = new SqlCommand();
                comandos.Connection = cn;
                comandos.CommandType = CommandType.Text;
                comandos.CommandText = "SELECT * FROM Categoria WHERE Titulo like = @vt";
                comandos.Parameters.AddWithValue("@vt", titulo);
                rd = comandos.ExecuteReader();

                while (rd.Read()){

                    // Categoria ct = new Categoria(){
                    //         IdCategoria = rd.GetInt32(0),
                    //             Titulo = rd.GetString(1)
                    // };
                    // lista.Add(ct);
                    lista.Add(new Categoria{
                                IdCategoria = rd.GetInt32(0),
                                Titulo = rd.GetString(1)
                                });
                }
                comandos.Parameters.Clear(); //limpa os parâmetros para a próxima execução
            }
            catch (SqlException se){
                throw new Exception("Erro ao tentar listar os dados. " + se.Message);
            }
            catch (Exception ex){
                throw new Exception("Erro inesperado: " + ex.Message);
            }
            finally{
                cn.Close();
            }
            return lista;
        }
    }
}