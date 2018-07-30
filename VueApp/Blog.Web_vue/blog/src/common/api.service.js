import { API_URL } from '@/common/config'

const ApiService = {
  get (Url, callback) {
    return fetch(Url)
      .then((response) => {
        if (response.ok) {
          return response.json()
        }
        console.log('error', 'Network response was not ok')
        throw new Error('Network response was not ok')
      })
      .then((json) => {
        callback(json)
      })
      .catch((error) => {
        console.log(error)
        throw new Error(`ApiService error: ${error}`)
      })
  }
}

export default ApiService

export const BlogPostService = {

  getPostsByTag (tag, callback) {
    let params = ''
    if ((tag !== '') && (tag !== undefined)) {
      params = '?tags=' + tag
    }
    return this.getPosts(params, callback)
  },

  getPostsById (id, callback) {
    let params = ''
    if ((id !== '') && (id !== undefined)) {
      params = '/' + id
    }
    return this.getPosts(params, callback)
  },

  getTags (callback) {
    let Url = API_URL + 'blog/tags'
    return ApiService.get(Url, callback)
  },

  getPosts (params, callback) {
    let Url = API_URL + 'blog/posts' + params
    return ApiService.get(Url, callback)
  }

}
