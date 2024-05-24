const baseurl = "https://sonicear-backendapi.azure-api.net/sonicear/apiMeasurement"

Vue.createApp({
    data() {
        return {
            items: [],
            errormessage: null,
            currentSort: null,
            searchQuery: "",
            filteredItems: [],
            pageAmount: null,
            rowsPerPage: 10,
            currentPage: 1
        }
    },
    async created() {
        await this.getItems();
        this.pageAmount = Math.ceil(this.items.length / this.rowsPerPage)
        await this.DisplayList()
        
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

                this.items = await response.data;
                
            } catch (ex) {
                alert(ex.message)
            }
        },
        setSort(sortBy) {
            let sortParam = "";
            switch (sortBy) {

                case 'id':
                    if (this.currentSort == 'id_desc') return ''
                    else return '?sortBy=id_desc'
                    break;
                case 'location':
                    if (this.currentSort == 'location_desc') return '?sortBy=location_asc'
                    else return '?sortBy=location_desc'
                    break;
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
            this.currentSort = sortParam;
            this.getItems();
        },
        getColor(level) {
            if (level < 20) {
                return '#29a8df'
            } else if (level < 40) {
                return '#3fa5b1'
            } else if (level < 60) {
                return '#54a383'
            } else if (level < 75) {
                return '#66a15d'
            } else if (level < 80) {
                return '#9bbb66'
            } else if (level < 90) {
                return '#ffc454'
            } else if (level < 100) {
                return '#f8ad3a'
            } else if (level < 115) {
                return '#e77f38'
            } else if (level < 130) {
                return '#e2682d'
            } else {
                return '#d95139'
            }
        },
        search() {
            const query = this.searchQuery.toLowerCase();
            this.filteredItems = this.items.filter(item =>
                item.device.location.toLowerCase().includes(query) ||
                item.timeStamp.toLowerCase().includes(query)
            )
        },
        async DisplayList() {
            let page = this.currentPage -1;
            let start = this.rowsPerPage * page;
            let end = start + this.rowsPerPage;
            let paginatedItems = this.items.slice(start, end);
            this.filteredItems = paginatedItems
          
        },
        
        setPage(number) {
            if (number < 1) number = 1;
            if (number > this.pageAmount) number = this.pageAmount;
            this.currentPage = number;
            this.DisplayList();
        }
    }
}).mount("#app") 