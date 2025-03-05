package oseg.petstore_examples

import org.openapitools.client.infrastructure.*
import org.openapitools.client.apis.*
import org.openapitools.client.models.*

import java.io.File
import java.time.LocalDate
import java.time.OffsetDateTime
import kotlin.collections.ArrayList
import kotlin.collections.List
import kotlin.collections.Map

class GetInventoryExample
{
    fun getInventory()
    {
        ApiClient.apiKey["api_key"] = "YOUR_API_KEY"

        try
        {
            val response = StoreApi().getInventory();

            println(response)
        } catch (e: ClientException) {
            println("4xx response calling StoreApi#getInventory")
            e.printStackTrace()
        } catch (e: ServerException) {
            println("5xx response calling StoreApi#getInventory")
            e.printStackTrace()
        }
    }
}
