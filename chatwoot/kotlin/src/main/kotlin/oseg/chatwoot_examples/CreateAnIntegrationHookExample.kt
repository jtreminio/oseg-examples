package oseg.chatwoot_examples

import com.chatwoot.client.infrastructure.*
import com.chatwoot.client.apis.*
import com.chatwoot.client.models.*

import java.io.File
import java.time.LocalDate
import java.time.OffsetDateTime
import kotlin.collections.ArrayList
import kotlin.collections.List
import kotlin.collections.Map
import com.squareup.moshi.adapter

@ExperimentalStdlibApi
class CreateAnIntegrationHookExample
{
    fun createAnIntegrationHook()
    {
        ApiClient.apiKey["api_access_token"] = "USER_API_KEY"
        // ApiClient.apiKey["api_access_token"] = "AGENT_BOT_API_KEY"
        // ApiClient.apiKey["api_access_token"] = "PLATFORM_APP_API_KEY"

        val integrationsHookCreatePayload = IntegrationsHookCreatePayload()

        try
        {
            val response = IntegrationsApi().createAnIntegrationHook(
                accountId = 0,
                _data = integrationsHookCreatePayload,
            )

            println(response)
        } catch (e: ClientException) {
            println("4xx response calling IntegrationsApi#createAnIntegrationHook")
            e.printStackTrace()
        } catch (e: ServerException) {
            println("5xx response calling IntegrationsApi#createAnIntegrationHook")
            e.printStackTrace()
        }
    }
}
