import { useState } from "react"
import { useNavigate } from "react-router-dom";
//import { useNavigate } from "react-router-dom"
import agileFoodFetch from "../../axios/config";
import './NewSupplier.css'

const NewSupplier = () => {

    const navigate = useNavigate();
    const id = 0;
    const [restaurantName, setRestaurantName] = useState();
    const [isActive, setIsActive] = useState(false);

    const handleCheckboxChange = () => {
        setIsActive(!isActive);
      };

    const createSupplier = async (e) => {
        e.preventDefault();
        
        if (!restaurantName) {
            alert("O nome do restaurante é obrigatório.");
            return;
        }

        const supplier = {id, restaurantName, isActive};
        console.log(supplier)

        try {
            await agileFoodFetch.post("/Supplier/Create", supplier)
        } catch (error) {
            console.log(error)
        }
        navigate('/Suppliers')

    }

  return (
    <div className="new-supplier-content">
        <form onSubmit={(e) => createSupplier(e)}>
            <div className="new-name">
                <label htmlFor="restauranteName">Nome do Restaurante: </label>
                <input 
                    type="text" 
                    name="restauranteName"
                    id="restauranteName"
                    placeholder="Digite o nome do novo restaurante"
                    onChange={(e) => setRestaurantName(e.target.value)}
                />
            </div>
            <div className="newIsActive">
                <label htmlFor="isActive">Esta ativo?</label>
                <input 
                    type="checkbox" 
                    name="isActive"
                    id="isActive"
                    onChange={() => handleCheckboxChange()}
                /> <label >sim</label>
            </div>
            <input className="btn" type="submit" value="Enviar"/>
        </form>
    </div>
  )
}

export default NewSupplier