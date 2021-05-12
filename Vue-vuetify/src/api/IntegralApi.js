import myaxios from '@/utils/myaxios'
export default {
    GetTop(pageSize, pageIndex) {
        return myaxios({
            url: `/Integral/GetTop`,
            method: 'post',
            data: {
                pageSize: pageSize,
                pageIndex: pageIndex
            }
        })
    },
}