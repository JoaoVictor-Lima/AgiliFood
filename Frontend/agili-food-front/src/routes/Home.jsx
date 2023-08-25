import { Link } from "react-router-dom"
import { useState } from "react"
import { useNavigate } from "react-router-dom"
import agileFoodFetch from "../axios/config"
import { useContext } from "react"
import { UserContext } from "./Context/UserContext"

import './Home.css'

const Home = () => {

    const [email, setEmail] = useState("");
    const {user, setUser} = useContext(UserContext);
    const navigate = useNavigate();
    const [returnMensage, setreturnMensage] = useState();

    const login  = async(e) => {
      e.preventDefault()

      try {
        const response = await agileFoodFetch.get(`/Collaborator/GetByEmail?email=${email}`)

        const data = response.data;
        setUser(data);
        console.log(user)

        setreturnMensage("Login Efetuado")

        if(data != null){
          console.log("Login efetuado com sucesso")
          navigate(`/Store`)
        }
      } catch (error) {
        console.log(error);

        setreturnMensage("Email não cadastrado");
      }
    } 

    return (
    <div>
      <div className="login-scream">
        <form onSubmit={(e) => login(e)}>
        <h2>Faça login com o e-mail</h2>
        <input 
          type="email" 
          name="email" 
          placeholder="joao123@gmail.com"
          onChange={(e) => setEmail(e.target.value)}
        />
        <p>{returnMensage}</p>
          <div className="btn-login">
            <input 
              type="submit"
              name="login"
              value="Logar"
            />
            <div className="new-register">
              <Link className="btn" to={'/NewCollaborator'}>Novo cadastro</Link>
            </div>
          </div>
        </form>
      </div>
    </div>
  )
}

export default Home