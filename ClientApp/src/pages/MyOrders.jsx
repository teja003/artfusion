import React,{useState, useEffect} from 'react'
import { Link } from "react-router-dom";
import CurrentUserProfile from '../components/CurrentUserProfile';
import ProductCardComponent from "../components/ProductCardComponent";
import { getRequestOptions } from "./../utils/utils";
import 'react-tabs/style/react-tabs.css';
import ProfileSideBarComponent from '../components/ProfileSideBarComponent';

function UserLikedProducts() {
     const [userLikedProducts, setUserLikedProducts] = useState(null);
    useEffect(() => {
        async function fetchUserLikedProducts(){
            let response = await fetch('/api/OrderDetails/current-user', getRequestOptions);
            let data = await response.json();
            setUserLikedProducts(data.data);
            console.log(data.data);
        }
        fetchUserLikedProducts()
    }, [])
    
  return (
    <div className="pt-[4rem] bg-gray-300 pl-10">
        <div className="flex space-between max-w-8xl mx-auto mt-4">
            <div>
                <ProfileSideBarComponent></ProfileSideBarComponent>
            </div>
            <div className="w-full">
                <div className="pl-10">
                    <h3>My Orders</h3>
                </div>
                <div className="mt-4 w-full">
                    <div className="w-full flex flex-wrap justify-center">
                        { userLikedProducts &&
                                        userLikedProducts.map(product => {
                                            return <ProductCardComponent key={product.id} id={product.id} name={product.name} description={product.description} price={product.price} image={product.image} likes={product.likes} likesCount={product.likes.length} createdAt={product.createdAt} status={product.status}></ProductCardComponent>
                                        })
                                    }
                    </div>
                    
                </div>
            </div>
        </div>
    </div>
  )
}

export default UserLikedProducts