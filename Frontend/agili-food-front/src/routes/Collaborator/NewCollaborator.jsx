import { useState } from "react"
import agileFoodFetch from "../../axios/config"
import './NewCollaborator.css'
import { useNavigate } from "react-router-dom"
import { useContext } from "react"
import { UserContext } from "../Context/UserContext"


const NewCollaborator = () => {

const {setUser} = useContext(UserContext);

const id = 0;
const [name, setName] = useState("");
const [email, setEmail] = useState("");
const isActive = true;
const newCollaborator = {id, name, email, isActive}

const navigate = useNavigate();
const [responseForUser, setResponseForUser] = useState();


const createUser = (e) => {
    e.preventDefault()

    try {
      agileFoodFetch.post("/Collaborator/Create", newCollaborator)

      if (newCollaborator.name === "" && newCollaborator.email === "" ){
        setResponseForUser("Preencha os dados anteriores para efetuar o cadastro:");
        throw new e("Preencha os dados")
      }

        setUser(newCollaborator)
        navigate('/Store')

    } catch (error) {
      console.log(responseForUser)
    }
    
}

  return (
    <div className="content">
      <div className="create-scream">
        <form onSubmit={(e) => createUser(e)}>
        <h2>Preencha os dados</h2>
        <div>
            <label>Nome: </label>
            <input 
                type="text" 
                name="name" 
                placeholder="Nome completo"
                onChange={(e) => setName(e.target.value)}
            />
        </div>
        <div>
            <label>Email: </label>
            <input 
                type="email" 
                name="email" 
                placeholder="joao123@gmail.com"
                onChange={(e) => setEmail(e.target.value)}
            />
        </div>
          <div className="btn-create">
            <input type="submit" value="Cadastrar"/>
          </div>
        </form>
      </div>
      <h3>{responseForUser}</h3>
    </div>
  )
}

export default NewCollaborator