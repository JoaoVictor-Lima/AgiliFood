import { useState } from "react"
import agileFoodFetch from "../../axios/config"
import { useNavigate, useParams } from "react-router-dom"

const EditProduct = () => {
  
    const navigate = useNavigate();

    const { id } = useParams();
    const [name, setName] = useState();
    const [description, setDescription] = useState();
    const [price, setPrice] = useState();
    const isActive = true;
    const { supplierId } = useParams();
    const newProduct = {id, name, description, price, isActive, supplierId}

    const newEditedProduct = async(e) => {
        e.preventDefault();
        await agileFoodFetch.put(`/Product/Update`, newProduct)

        navigate(`/Products/${supplierId}`)
    }
  
  
    return (
    <div>
        <form onSubmit={(e) => newEditedProduct(e)}>
            <div>
                <label>Nome: </label>
                <input 
                    type="text" 
                    name="name"
                    id="name"
                    placeholder="Digite o Novo Nome"
                    onChange={(e) => setName(e.target.value)}
                />
            </div>
            <div>
                <label>Descrição: </label>
                <textarea
                    type="text" 
                    name="description"
                    id="description"
                    placeholder="Digite aqui a nova descrição"
                    onChange={(e) => setDescription(e.target.value)}
                 />
            </div>
            <div>
                <label>Price</label>
                <input 
                    type="Number"
                    step="0.01"
                    name="price"
                    id="price"
                    placeholder="00,00"
                    onChange={(e) => setPrice(e.target.value)}
                />
            </div>
            <input type="submit" />
        </form>
    </div>
  )
}

export default EditProduct