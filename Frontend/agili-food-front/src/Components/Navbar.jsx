import { Link } from "react-router-dom"
import "./Navbar.css"
import { useContext } from "react"
import { UserContext } from "../routes/Context/UserContext"

const Navbar = () => {
    const {user} = useContext(UserContext);

    return (
        <div>
            {!Object.keys(user).length ? (
                <nav className="navbar">
                <div className="Title">
                    <h2>
                        <Link to={`/`}>Agili Food</Link>
                    </h2>
                </div>
                <ul>
                    <li>
                        <Link to={`/`}>Home</Link>
                    </li>
                </ul>
            </nav>
            ) : (
                <nav className="navbar">
                    <div className="Title">
                        <h2>
                            <Link to={`/`}>Agili Food</Link>
                        </h2>
                        <p>{user.name}</p>
                    </div>
                    <ul>
                        <li>
                            <Link to={`/Store`}>Store</Link>
                        </li>
                        <li>
                            <Link to={`/Collaborators`}>Colaboradores</Link>
                        </li>
                        <li>
                            <Link to={`/Suppliers`}>Fornecedores</Link>
                        </li>
                    </ul>
                </nav>
            )}
        </div>
    );
}

export default Navbar