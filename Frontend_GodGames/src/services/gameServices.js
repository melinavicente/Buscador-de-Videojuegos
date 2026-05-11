import axios from 'axios'

const api = axios.create({
    baseURL: 'http://localhost:5045/api'
})

export const getGames = () => api.get('/videogame').then(r => r.data)
export const getGame = (id) => api.get(`/videogame/${id}`).then(r => r.data)