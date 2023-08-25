import { useParams } from "react-router-dom";
import agileFoodFetch from "../../axios/config";
import { useState } from "react";
import { useNavigate } from "react-router-dom";

const NewProducts = () => {

    const navigate = useNavigate();

    const id = 0;
    const [name, setName] =useState();
    const [description, setDescription] = useState();
    var [price, setPrice] = useState();
    const isActive = true;
    const { supplierId } = useParams(); 

    const addProduct = async (e) => {
        e.preventDefault();

        price = parseFloat(price)
        const newProduct = {id, name, description, price, isActive, supplierId}
        await agileFoodFetch.post(`/Product/Create`, newProduct)

        navigate(`/Products/${supplierId}`)
    }


  return (
    <div>
        <div>
            <form onSubmit={(e) => addProduct(e)} >
                <div>
                    <label>Nome do produto: </label>
                    <input 
                        type="text" 
                        name="name"
                        id="name"
                        placeholder="Marmita media chinsa"
                        onChange={(e) => setName(e.target.value)}
                    />
                </div>
                <div>
                    <label>Descrição: </label>
                    <input 
                        type="text" 
                        name="description"
                        id="description"
                        placeholder="marmita de 500 gramas com yaksoba, arroz feijão, etc..."
                        onChange={(e) => setDescription(e.target.value)}
                    />
                </div>
                <div>
                    <label>Preço: R$:</label>
                    <input 
                        type="Number"
                        step="0.01"
                        name="price"
                        id="price"
                        placeholder="00,00"
                        onChange={(e) => setPrice(e.target.value)} 
                    />
                </div>
                <input type="submit"/>
            </form>
        </div>
    </div>
  )
}

export default NewProducts