import React, {useEffect,useState, useContext } from 'react'
import ProductCardComponent from '../components/ProductCardComponent';
import CategoriesComponent from '../components/CategoriesComponent';
import {useParams, useNavigate, createSearchParams} from "react-router-dom"
import { getRequestOptions } from '../utils/utils';
import { appContext } from '../context/appContext';
import {Toaster} from 'react-hot-toast';

function ProductsPage() {
  const [products, setProducts] = useState([])
  const [categoryName, setCategoryName] = useState()
  const {categoryId} = useParams();
  const {categories} = useContext(appContext)
  const navigate = useNavigate()


  useEffect(() => {
      async function fetchProducts() {
          let response = await fetch('/api/Products',getRequestOptions);
          let data = await response.json()
          setProducts(data)
      }
      async function fetchProductsByCategory(){
        let response = await fetch(`/api/Products/category/${categoryId}`,getRequestOptions);
          let data = await response.json()
          setProducts(data)
          setCategoryName(categories.filter(category => category.categoryId==categoryId)[0].name)
          console.log(categories.filter(category => category.categoryId==categoryId));
      }
      if(!categoryId){
        fetchProducts()
      }else{
        fetchProductsByCategory()
      }
    }, [categoryId])
    
  async function handleSearch(e){
    navigate({
      pathname:"/products/search",
      search: createSearchParams({
        search:e.target.search.value
      }).toString()
    })
  }

  return (
    <div className="pt-[4rem]">
      <div className="flex max-w-8xl mx-auto pt-4">
        <div className="z-0 md:block hidden">
          <CategoriesComponent></CategoriesComponent>
        </div>
        <div className="w-full z-0">
          <div class="w-full sm:flex items-center justify-between">
            <div>
              {
                categoryId==null?<><h2 className="ml-6">All Arts</h2></>:<><h2 className="ml-6">{categoryName}</h2></>
              }
            </div>
            <div className="w-2/3"> 
              <form onSubmit={handleSearch}>   
                  <label for="default-search" class="mb-2 text-sm font-medium text-gray-900 sr-only dark:text-white">Search</label>
                  <div class="relative">
                      <div class="absolute inset-y-0 left-0 flex items-center pl-3 pointer-events-none">
                          <svg class="w-4 h-4 text-gray-500 dark:text-gray-400" aria-hidden="true" xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 20 20">
                              <path stroke="currentColor" stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="m19 19-4-4m0-7A7 7 0 1 1 1 8a7 7 0 0 1 14 0Z"/>
                          </svg>
                      </div>
                      <input name="search" type="search" id="default-search" class="block w-full pt-4 pb-4 pr-4 pl-10 text-sm text-gray-900 border border-gray-300 rounded-lg bg-gray-50 focus:ring-blue-500 focus:border-blue-500 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500" placeholder="Search Products, Users..." required/>
                      <button type="submit" class="text-white absolute right-2.5 bottom-3.5 bg-blue-700 hover:bg-blue-800 focus:ring-4 focus:outline-none focus:ring-blue-300 font-medium rounded-lg text-sm px-4 py-2 dark:bg-blue-600 dark:hover:bg-blue-700 dark:focus:ring-blue-800">Search</button>
                  </div>
              </form>
            </div>
          </div>
          <div className="w-full flex flex-wrap justify-center -z-10 mt-4">
            {
              products.map(product => {
                return <ProductCardComponent key={product.id} ownerId={product.ownerId} id={product.id} name={product.name} description={product.description} price={product.price} image={product.image} likes={product.likes} likesCount={product.likes.length} createdAt={product.createdAt} status={product.status}></ProductCardComponent>
              })
            }
          </div>
        </div>
      </div>
            <Toaster toastOptions={{
                success:{
                  style:{
                      padding:"24px",
              }
              },error:{
                style:{
                  padding: "24px"
                }
              }
            }} containerStyle={{
                              top: 40,
                              right: 40
                          }}/>
    </div>
  )
}

export default ProductsPage