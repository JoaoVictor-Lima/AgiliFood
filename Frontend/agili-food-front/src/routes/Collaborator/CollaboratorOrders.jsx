import { useEffect, useState } from "react"
import agileFoodFetch from "../../axios/config"
import { useParams } from "react-router-dom";

import { format } from 'date-fns';
import { ptBR } from 'date-fns/locale';

import './CollaboratorOrders.css'

const CollaboratorOrders = () => {
    const { id } = useParams();
    const [orders, setOrders] = useState([]);
    const [selectedMonth, setSelectedMonth] = useState(""); 

    const filterOrdersByMonth = (month) => {
        const filteredOrders = orders.filter((order) => {
            const orderMonth = new Date(order.datePurchase).getMonth() + 1; // +1 para coincidir com o formato de mês
            return orderMonth === month;
        });
        return filteredOrders;
    };

    const handleMonthSelection = (event) => {
        const selectedMonthValue = event.target.value;
        setSelectedMonth(selectedMonthValue);
    };

    useEffect(() => {
        const GetOrdersByCollaboratorId = async () => {
            try {
                const response = await agileFoodFetch.get(`/Order/GetOrdersByCollaboratorId?id=${id}`);
                const data = response.data;
                setOrders(data);
                console.log(data);
            } catch (error) {
                console.error('Erro ao obter os pedidos:', error);
            }
        }
        
        GetOrdersByCollaboratorId();
    }, [id]);

  return (
    <div>
        <div className="MonthSelect">
            <label>Selecione o mes: </label>
            <select value={selectedMonth} onChange={handleMonthSelection}>
                <option value="">Selecione um mês</option>
                <option value="1">Janeiro</option>
                <option value="2">Fevereiro</option>
                <option value="3">Março</option>
                <option value="4">Abril</option>
                <option value="5">Maio</option>
                <option value="6">Junho</option>
                <option value="7">Julho</option>
                <option value="8">Agosto</option>
                <option value="9">Setembro</option>
                <option value="10">Outubro</option>
                <option value="11">Novembro</option>
                <option value="12">Dezembro</option>
            </select>
        </div>
        <div>
            {selectedMonth ? (
            filterOrdersByMonth(parseInt(selectedMonth)).length > 0 ? (
                filterOrdersByMonth(parseInt(selectedMonth)).map((order) => (
                <div key={order.id} className=" CollaboratorOrders">
                    <h2>Nota de pedido</h2>
                    <div className="OrderContent">
                        <p>Data do pedido: {format(new Date(order.datePurchase), 'dd/MM/yyyy', { locale: ptBR })}</p> 
                        <p>Valor Total do pedido: {order.totalValue}</p>
                    </div>
                    <div className="ProductsContent">
                        <h3>Produtos do pedido</h3>
                        {order.products.map((product) => (
                        <div key={product.id} className="OrderProduct">
                            <p>Nome do produto: {product.name}</p>
                            <p>Descrição do produto {product.description}</p>
                            <p>Valor do produto: {product.price}</p>
                        </div>
                        ))}
                    </div>                    
                </div>
                ))
            ) : (
                <p>Não existe nenhum pedido deste colaborador para este mês.</p>
            )
            ) : (
            orders.length > 0 ? (
                orders.map((order) => (
                <div key={order.id}>
                    {/* Renderização dos pedidos completos */}
                </div>
                ))
            ) : (
                <p>Não existem pedidos neste momento.</p>
            )
            )}
        </div>
    </div>
  )
}

export default CollaboratorOrders