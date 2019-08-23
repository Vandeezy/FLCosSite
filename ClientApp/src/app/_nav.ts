interface NavAttributes {
  [propName: string]: any;
}
interface NavWrapper {
  attributes: NavAttributes;
  element: string;
}
interface NavBadge {
  text: string;
  variant: string;
}
interface NavLabel {
  class?: string;
  variant: string;
}

export interface NavData {
  name?: string;
  url?: string;
  icon?: string;
  badge?: NavBadge;
  title?: boolean;
  children?: NavData[];
  variant?: string;
  attributes?: NavAttributes;
  divider?: boolean;
  class?: string;
  label?: NavLabel;
  wrapper?: NavWrapper;
}

export const navItems: NavData[] = [
  {
    name: 'Dashboard',
    url: '/dashboard',
    icon: 'icon-speedometer',
    badge: {
      variant: 'info',
      text: 'NEW'
    }
  },
  {
    title: true,
    name: 'Introduction'
  },
  {
    name: 'Biography',
    url: '/theme/colors',
    icon: 'icon-drop'
  },
  {
    title: true,
    name: 'Travels'
  },
  {
    name: 'Germany',
    url: '/base',
    icon: 'icon-puzzle',
    children: [
      {
        name: 'Munich',
        url: '/base/cards',
        icon: 'icon-puzzle'
      },
      {
        name: 'Regensburg',
        url: '/base/carousels',
        icon: 'icon-puzzle'
      },
      {
        name: 'Berlin',
        url: '/base/collapses',
        icon: 'icon-puzzle'
      },
      {
        name: 'Dresden',
        url: '/base/forms',
        icon: 'icon-puzzle'
      },
      {
        name: 'Neuschwanstein',
        url: '/base/paginations',
        icon: 'icon-puzzle'
      }
    ]
  },
  {
    name: 'Switzerland',
    url: '/base',
    icon: 'icon-puzzle',
    children: [
      {
        name: 'Zurich',
        url: '/base/cards',
        icon: 'icon-puzzle'
      },
      {
        name: 'St. Gallen',
        url: '/base/carousels',
        icon: 'icon-puzzle'
      }
    ]
  },
  {
    name: 'Czech Republic',
    url: '/base',
    icon: 'icon-puzzle',
    children: [
      {
        name: 'Prague',
        url: '/base/cards',
        icon: 'icon-puzzle'
      }
    ]
  },
  {
    title: true,
    name: 'Hobbies'
  },
  {
    name: 'Painting',
    url: '/charts',
    icon: 'icon-pie-chart'
  },
  {
    name: 'Cycling',
    url: '/charts',
    icon: 'icon-pie-chart'
  },
  {
    name: 'Instrument',
    url: '/charts',
    icon: 'icon-pie-chart'
  },
  
  {
    divider: true
  },
  {
    title: true,
    name: 'Extras',
  },
  {
    name: 'Pages',
    url: '/pages',
    icon: 'icon-star',
    children: [
      {
        name: 'Login',
        url: '/login',
        icon: 'icon-star'
      },
      {
        name: 'Register',
        url: '/register',
        icon: 'icon-star'
      },
      {
        name: 'Error 404',
        url: '/404',
        icon: 'icon-star'
      },
      {
        name: 'Error 500',
        url: '/500',
        icon: 'icon-star'
      }
    ]
  },
  {
    name: 'Disabled',
    url: '/dashboard',
    icon: 'icon-ban',
    badge: {
      variant: 'secondary',
      text: 'NEW'
    },
    attributes: { disabled: true },
  },
  
];
