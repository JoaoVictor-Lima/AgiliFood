import agileFoodFetch from "../../axios/config"
import { useState, useEffect } from "react"
import { Link } from "react-router-dom";

import './Collaborators.css'

const Collaborators = () => {
    
    const [collaborators, setCollaborators] = useState([]);

    const getAllCollaborators = async() => {
        const response = await agileFoodFetch.get(`/Collaborator/GetAll`)
        const data = response.data;
        console.log(data)
        setCollaborators(data);
    }

    useEffect(() => {
        getAllCollaborators();
    }, [])

  return (
    <div className="CollaboratorContent">
        <h1>TODOS OS COLABORADORES</h1>
        <div className="Collaborators">
            {collaborators.map((collaborator) => (
                <div key={collaborator.id} className="CollaboratorDescription">
                    <h3>Nome: {collaborator.name}</h3>
                    <p>Email: {collaborator.email}</p>
                    <Link to={`/CollaboratorOrders/${collaborator.id}`}>Historico de pedidos</Link>
                </div>
            ))}
        </div>
    </div>
  )
}

export default Collaborators