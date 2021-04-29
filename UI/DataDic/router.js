import Layout from '@/layout'
export default [
    {
        path: '/datadic',
        component: Layout,
        redirect: '/datadic/list',
        alwaysShow: false,
        name: 'DataDic',
        meta: {
            title: '数据字典',
            icon: 'system'
        },
        children: [
            { 
                path: 'list',
                name: 'List',
                component: () => import('./views/index'),
                meta: {
                    title: '数据字典',
                    icon: 'system'
                }
            }
        ]
    }
]