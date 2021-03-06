﻿/*
This file is part of MonoBoss Application Server.
    MonoBoss Application Server is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.
    MonoBoss Application Server is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.
    You should have received a copy of the GNU General Public License
    along with Nome-Programma.  If not, see <http://www.gnu.org/licenses/>.
*/
using System;
namespace MonoBoss.Kernel.Common
{
    public interface IServerInstance
    {
        System.Collections.Generic.List<domainprofileType> getDomainProfile();
        System.Collections.Generic.List<Extension> getRequiredExtention();
        System.Collections.Generic.List<specifiedinterfaceType> getRequiredInterfaces();
        System.Collections.Generic.List<securityrealmType> getSecurityRealms();
        System.Collections.Generic.List<standalonesocketbindinggroupType> getSocketBindGroup();
        System.Collections.Generic.List<standaloneprofileType> getStandAloneProfile();
    }
}
 