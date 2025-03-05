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
import com.squareup.moshi.adapter

@ExperimentalStdlibApi
class GetPetByIdExample
{
    fun getPetById()
    {
        ApiClient.apiKey["api_key"] = "YOUR_API_KEY"

        try
        {
            val response = PetApi().getPetById(
                petId = 12345,
            )

            println(response)
        } catch (e: ClientException) {
            println("4xx response calling PetApi#getPetById")
            e.printStackTrace()
        } catch (e: ServerException) {
            println("5xx response calling PetApi#getPetById")
            e.printStackTrace()
        }
    }
}
