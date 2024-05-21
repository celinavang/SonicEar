const baseurl = "https://sonicear-backendapi.azure-api.net/sonicear/apiMeasurement"

Vue.createApp({
    data() {
        return {
            items: [],
            errormessage: null,
            currentSort: null,
        }
    },
    async created() {
        this.getItems()
    },
    methods: {
        async getItems() {
            try {
                let response = await axios.get(baseurl)

                const urlParems = new URLSearchParams(location.search)

                if (urlParems.has('sortBy')) {
                    this.currentSort = urlParems.get('sortBy')
                    console.log(urlParems.get('sortBy'))
                    response = await axios.get(baseurl + '?sortBy=' + this.currentSort)
                }

                this.items = await response.data
            } catch (ex) {
                alert(ex.message)
            }
        },
        setSort(sortBy) {
            switch (sortBy) {

                case 'id':
                    if (this.currentSort == 'id_desc') return ''
                    else return '?sortBy=id_desc'
                    break;
                //case 'location':
                //    if (this.currentSort == 'location_desc') return '?sortBy=location_asc'
                //    else return '?sortBy=location_desc'
                 /*   break;*/
                case 'time':
                    if (this.currentSort == 'time_desc') return '?sortBy=time_asc'
                    else return '?sortBy=time_desc'
                    break;
                case 'measurement':
                    if (this.currentSort == 'noise_desc') return '?sortBy=noise_asc'
                    else return '?sortBy=noise_desc'
                    break;
                default:
                    break;
            }
        }
    }
}).mount("#app")